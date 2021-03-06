﻿namespace LinkGreenODBCUtility
{
    partial class CreateTask
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateTask));
            this.taskComboBox = new System.Windows.Forms.ComboBox();
            this.taskLabel = new System.Windows.Forms.Label();
            this.startDateTime = new System.Windows.Forms.DateTimePicker();
            this.startDateTimeLabel = new System.Windows.Forms.Label();
            this.repeatComboBox = new System.Windows.Forms.ComboBox();
            this.repeatLabel = new System.Windows.Forms.Label();
            this.create = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.lblExternalExecutable = new System.Windows.Forms.Label();
            this.txtExternalExecutable = new System.Windows.Forms.TextBox();
            this.txtExternalParameters = new System.Windows.Forms.TextBox();
            this.lblExternalParameters = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // taskComboBox
            // 
            this.taskComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.taskComboBox.FormattingEnabled = true;
            this.taskComboBox.Location = new System.Drawing.Point(16, 29);
            this.taskComboBox.Name = "taskComboBox";
            this.taskComboBox.Size = new System.Drawing.Size(385, 21);
            this.taskComboBox.TabIndex = 0;
            this.taskComboBox.SelectedIndexChanged += new System.EventHandler(this.taskComboBox_SelectedIndexChanged);
            // 
            // taskLabel
            // 
            this.taskLabel.AutoSize = true;
            this.taskLabel.Location = new System.Drawing.Point(13, 13);
            this.taskLabel.Name = "taskLabel";
            this.taskLabel.Size = new System.Drawing.Size(34, 13);
            this.taskLabel.TabIndex = 1;
            this.taskLabel.Text = "Task:";
            // 
            // startDateTime
            // 
            this.startDateTime.CustomFormat = "MM/dd/yyyy hh:mm:ss";
            this.startDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startDateTime.Location = new System.Drawing.Point(16, 174);
            this.startDateTime.MinDate = new System.DateTime(2017, 11, 9, 0, 0, 0, 0);
            this.startDateTime.Name = "startDateTime";
            this.startDateTime.Size = new System.Drawing.Size(385, 20);
            this.startDateTime.TabIndex = 2;
            this.startDateTime.Value = new System.DateTime(2017, 11, 9, 15, 25, 50, 0);
            // 
            // startDateTimeLabel
            // 
            this.startDateTimeLabel.AutoSize = true;
            this.startDateTimeLabel.Location = new System.Drawing.Point(13, 158);
            this.startDateTimeLabel.Name = "startDateTimeLabel";
            this.startDateTimeLabel.Size = new System.Drawing.Size(86, 13);
            this.startDateTimeLabel.TabIndex = 3;
            this.startDateTimeLabel.Text = "Start Date/Time:";
            // 
            // repeatComboBox
            // 
            this.repeatComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.repeatComboBox.FormattingEnabled = true;
            this.repeatComboBox.Location = new System.Drawing.Point(16, 222);
            this.repeatComboBox.Name = "repeatComboBox";
            this.repeatComboBox.Size = new System.Drawing.Size(385, 21);
            this.repeatComboBox.TabIndex = 4;
            // 
            // repeatLabel
            // 
            this.repeatLabel.AutoSize = true;
            this.repeatLabel.Location = new System.Drawing.Point(13, 206);
            this.repeatLabel.Name = "repeatLabel";
            this.repeatLabel.Size = new System.Drawing.Size(45, 13);
            this.repeatLabel.TabIndex = 5;
            this.repeatLabel.Text = "Repeat:";
            // 
            // create
            // 
            this.create.Location = new System.Drawing.Point(209, 265);
            this.create.Name = "create";
            this.create.Size = new System.Drawing.Size(75, 23);
            this.create.TabIndex = 6;
            this.create.Text = "Create";
            this.create.UseVisualStyleBackColor = true;
            this.create.Click += new System.EventHandler(this.create_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(128, 265);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 7;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // lblExternalExecutable
            // 
            this.lblExternalExecutable.AutoSize = true;
            this.lblExternalExecutable.Location = new System.Drawing.Point(13, 64);
            this.lblExternalExecutable.Name = "lblExternalExecutable";
            this.lblExternalExecutable.Size = new System.Drawing.Size(104, 13);
            this.lblExternalExecutable.TabIndex = 8;
            this.lblExternalExecutable.Text = "External Executable:";
            this.lblExternalExecutable.Visible = false;
            // 
            // txtExternalExecutable
            // 
            this.txtExternalExecutable.Location = new System.Drawing.Point(16, 80);
            this.txtExternalExecutable.Name = "txtExternalExecutable";
            this.txtExternalExecutable.Size = new System.Drawing.Size(385, 20);
            this.txtExternalExecutable.TabIndex = 9;
            this.txtExternalExecutable.Visible = false;
            // 
            // txtExternalParameters
            // 
            this.txtExternalParameters.Location = new System.Drawing.Point(16, 121);
            this.txtExternalParameters.Name = "txtExternalParameters";
            this.txtExternalParameters.Size = new System.Drawing.Size(385, 20);
            this.txtExternalParameters.TabIndex = 11;
            this.txtExternalParameters.Visible = false;
            // 
            // lblExternalParameters
            // 
            this.lblExternalParameters.AutoSize = true;
            this.lblExternalParameters.Location = new System.Drawing.Point(13, 105);
            this.lblExternalParameters.Name = "lblExternalParameters";
            this.lblExternalParameters.Size = new System.Drawing.Size(63, 13);
            this.lblExternalParameters.TabIndex = 10;
            this.lblExternalParameters.Text = "Parameters:";
            this.lblExternalParameters.Visible = false;
            // 
            // CreateTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 328);
            this.Controls.Add(this.txtExternalParameters);
            this.Controls.Add(this.lblExternalParameters);
            this.Controls.Add(this.txtExternalExecutable);
            this.Controls.Add(this.lblExternalExecutable);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.create);
            this.Controls.Add(this.repeatLabel);
            this.Controls.Add(this.repeatComboBox);
            this.Controls.Add(this.startDateTimeLabel);
            this.Controls.Add(this.startDateTime);
            this.Controls.Add(this.taskLabel);
            this.Controls.Add(this.taskComboBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateTask";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Task";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CreateTask_FormClosed);
            this.Load += new System.EventHandler(this.CreateTask_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox taskComboBox;
        private System.Windows.Forms.Label taskLabel;
        private System.Windows.Forms.DateTimePicker startDateTime;
        private System.Windows.Forms.Label startDateTimeLabel;
        private System.Windows.Forms.ComboBox repeatComboBox;
        private System.Windows.Forms.Label repeatLabel;
        private System.Windows.Forms.Button create;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label lblExternalExecutable;
        private System.Windows.Forms.TextBox txtExternalExecutable;
        private System.Windows.Forms.TextBox txtExternalParameters;
        private System.Windows.Forms.Label lblExternalParameters;
    }
}