﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using System.Data.Odbc;

namespace LinkGreenODBCUtility
{
    public class Logger
    {
        private static string DatetimeFormat;
        private static TelemetryClient tc = new TelemetryClient();
        private static LoggerModel _loggerModel;
        public static readonly Logger Instance = new Logger();
        private static Dictionary<SeverityLevel, string> LevelNames = new Dictionary<SeverityLevel, string>()
        {
            { SeverityLevel.Information, "INFO" },
            { SeverityLevel.Verbose, "DEBUG" },
            { SeverityLevel.Warning, "WARN" },
            { SeverityLevel.Error, "ERROR" },
            { SeverityLevel.Critical, "FATAL" }
        };

        static Logger()
        {
            DatetimeFormat = "yyyy-MM-dd HH:mm:ss.fff";
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string apiKey = config.AppSettings.Settings["ApiKey"].Value;
            string clientName = config.AppSettings.Settings["ClientName"].Value;
            string userName = config.AppSettings.Settings["UserName"].Value;
            string emailAddress = config.AppSettings.Settings["EmailAddress"].Value;
            string phoneNumber = config.AppSettings.Settings["PhoneNumber"].Value;
            string installationId = config.AppSettings.Settings["InstallationId"].Value;
            _loggerModel = new LoggerModel()
            {
                ApiKey = !string.IsNullOrEmpty(apiKey) ? apiKey : null,
                ClientName = !string.IsNullOrEmpty(clientName) ? clientName : null,
                UserName = !string.IsNullOrEmpty(userName) ? userName : null,
                EmailAddress = !string.IsNullOrEmpty(emailAddress) ? emailAddress : null,
                PhoneNumber = !string.IsNullOrEmpty(phoneNumber) ? phoneNumber : null,
                InstallationId = !string.IsNullOrEmpty(installationId) ? installationId : null,
                ApplicationVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString()
            };
        }

        /// <summary>
        /// Log a debug message
        /// </summary>
        /// <param name="text">Message</param>
        public void Debug(string text)
        {
            if (Settings.DebugMode)
            {
                SendLog(SeverityLevel.Verbose, text);
            }
            SaveLog(SeverityLevel.Verbose, text);
        }

        /// <summary>
        /// Log an error message
        /// </summary>
        /// <param name="text">Message</param>
        public void Error(string text)
        {
            SendLog(SeverityLevel.Error, text);
            SaveLog(SeverityLevel.Error, text);
        }

        /// <summary>
        /// Log a fatal error message
        /// </summary>
        /// <param name="text">Message</param>
        public void Fatal(string text)
        {
            SendLog(SeverityLevel.Critical, text);
            SaveLog(SeverityLevel.Critical, text);
        }

        /// <summary>
        /// Log an info message
        /// </summary>
        /// <param name="text">Message</param>
        public void Info(string text)
        {
            if (Settings.DebugMode)
            {
                SendLog(SeverityLevel.Information, text);
            }
            SaveLog(SeverityLevel.Information, text);
        }

        /// <summary>
        /// Log a waning message
        /// </summary>
        /// <param name="text">Message</param>
        public void Warning(string text)
        {
            SendLog(SeverityLevel.Warning, text);
            SaveLog(SeverityLevel.Warning, text);
        }

        /// <summary>
        /// Format a log message based on log level and send to azure application insights
        /// </summary>
        /// <param name="level">Log level</param>
        /// <param name="text">Log message</param>
        private void SendLog(SeverityLevel level, string text)
        {
            string formattedLogText = FormattedLog(level, text);

            // Send Log to Azure application insights
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            bool ApplicationInsights = Convert.ToInt32(config.AppSettings.Settings["ApplicationInsights"].Value) == 1;

            if (ApplicationInsights)
            {
                tc.TrackTrace(
                    formattedLogText,
                    level,
                    new Dictionary<string, string>
                    {
                        {"ApiKey", _loggerModel.ApiKey ?? "Unknown"},
                        {"InstallationId", _loggerModel.InstallationId ?? "Unknown"},
                        {"Name", _loggerModel.UserName ?? "Unknown"},
                        {"Email", _loggerModel.EmailAddress ?? "Unknown"},
                        {"Phone", _loggerModel.PhoneNumber ?? "Unknown"}
                    }
                );
            }
        }

        private void SaveLog(SeverityLevel level, string text)
        {
            var _connection = new OdbcConnection();
            _connection.ConnectionString = $"DSN={Settings.DsnName}";
            text = text.Replace("'", "''");
            text = text.Replace("\"", "\\\"");
            var command = new OdbcCommand($"INSERT INTO `Log` (`Level`, `Message`, `Timestamp`) VALUES('{LevelNames[level]}', '{text}', '{DateTime.Now}')")
            {
                Connection = _connection
            };

            _connection.Open();
            try
            {
                command.ExecuteNonQuery();
            }
            finally
            {
                _connection.Close();
            }
        }

        private string FormattedLog(SeverityLevel level, string text)
        {
            string pretext;
            switch (level)
            {
                case SeverityLevel.Information: pretext = " [INFO]    "; break;
                case SeverityLevel.Verbose: pretext = " [DEBUG]   "; break;
                case SeverityLevel.Warning: pretext = " [WARNING] "; break;
                case SeverityLevel.Error: pretext = " [ERROR]   "; break;
                case SeverityLevel.Critical: pretext = " [FATAL]   "; break;
                default: pretext = ""; break;
            }

            return pretext + text;
        }
    }
}