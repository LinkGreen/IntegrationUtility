﻿using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using Microsoft.CSharp.RuntimeBinder;

namespace DataTransfer.AccessDatabase
{
    public class PriceLevelRepository : OleDbRepository<PriceLevel>
    {
        public PriceLevelRepository(string connectionString) : base(connectionString)
        {
        }

        #region Private Consts

        private const string TableName = "PriceLevels";
        private const string TableKey = "Id";

        #endregion

        #region Get

        public IEnumerable<PriceLevel> GetAll()
        {
            // DBAs across the country are having strokes 
            //  over this next command!
            using (var command = new OleDbCommand($"SELECT * FROM {TableName}"))
            {
                return GetRecords(command);
            }
        }

        #endregion

        public void ClearAll()
        {
            using (var command = new OleDbCommand($"DELETE * FROM {TableName}"))
            {
                ExecuteCommand(command);
            }
        }

        public override void SaveFieldMapping(string fieldName, string mappingName)
        {
            using (var command = new OleDbCommand($"UPDATE `FieldMappings` SET `MappingName` = '{mappingName}' WHERE `FieldName` = '{fieldName}' AND `TableName` = '{TableName}'"))
            {
                ExecuteCommand(command);
            }
        }

        // NOTE : this is the wire-up of the local odbc table to strongly typed object to be sent via api to LG db
        protected override PriceLevel PopulateRecord(dynamic reader)
        {
            try
            {
                return new PriceLevel
                {
                    Name = reader.Name,
                    ExternalReference = reader.ExternalReference,
                    EffectiveDate = reader.EffectiveDate,
                    EndDate = reader.EndDate
                };
            }
            catch (RuntimeBinderException exception)
            {
                Console.WriteLine(exception);
                throw new InvalidDataException("One of the fields in the source ODBC database has an invalid column type or value", exception);
            }
        }
    }
}