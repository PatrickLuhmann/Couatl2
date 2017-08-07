namespace Couatl2
{
	partial class RecordCashDividendDialog
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
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			this.dateTimePickerDate = new System.Windows.Forms.DateTimePicker();
			this.labelDate = new System.Windows.Forms.Label();
			this.textBoxValue = new System.Windows.Forms.TextBox();
			this.labelValue = new System.Windows.Forms.Label();
			this.comboBoxAccount = new System.Windows.Forms.ComboBox();
			this.labelAccount = new System.Windows.Forms.Label();
			this.textBoxSecurity = new System.Windows.Forms.TextBox();
			this.labelSecurity = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(174, 173);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 15;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// buttonSave
			// 
			this.buttonSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonSave.Location = new System.Drawing.Point(57, 173);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 14;
			this.buttonSave.Text = "Save";
			this.buttonSave.UseVisualStyleBackColor = true;
			// 
			// dateTimePickerDate
			// 
			this.dateTimePickerDate.Location = new System.Drawing.Point(83, 88);
			this.dateTimePickerDate.Name = "dateTimePickerDate";
			this.dateTimePickerDate.Size = new System.Drawing.Size(200, 20);
			this.dateTimePickerDate.TabIndex = 13;
			// 
			// labelDate
			// 
			this.labelDate.AutoSize = true;
			this.labelDate.Location = new System.Drawing.Point(12, 94);
			this.labelDate.Name = "labelDate";
			this.labelDate.Size = new System.Drawing.Size(30, 13);
			this.labelDate.TabIndex = 12;
			this.labelDate.Text = "Date";
			// 
			// textBoxValue
			// 
			this.textBoxValue.Location = new System.Drawing.Point(83, 62);
			this.textBoxValue.MaxLength = 16;
			this.textBoxValue.Name = "textBoxValue";
			this.textBoxValue.Size = new System.Drawing.Size(100, 20);
			this.textBoxValue.TabIndex = 11;
			// 
			// labelValue
			// 
			this.labelValue.AutoSize = true;
			this.labelValue.Location = new System.Drawing.Point(12, 65);
			this.labelValue.Name = "labelValue";
			this.labelValue.Size = new System.Drawing.Size(34, 13);
			this.labelValue.TabIndex = 10;
			this.labelValue.Text = "Value";
			// 
			// comboBoxAccount
			// 
			this.comboBoxAccount.FormattingEnabled = true;
			this.comboBoxAccount.Location = new System.Drawing.Point(83, 9);
			this.comboBoxAccount.Name = "comboBoxAccount";
			this.comboBoxAccount.Size = new System.Drawing.Size(200, 21);
			this.comboBoxAccount.TabIndex = 9;
			// 
			// labelAccount
			// 
			this.labelAccount.AutoSize = true;
			this.labelAccount.Location = new System.Drawing.Point(12, 12);
			this.labelAccount.Name = "labelAccount";
			this.labelAccount.Size = new System.Drawing.Size(47, 13);
			this.labelAccount.TabIndex = 8;
			this.labelAccount.Text = "Account";
			// 
			// textBoxSecurity
			// 
			this.textBoxSecurity.Location = new System.Drawing.Point(83, 36);
			this.textBoxSecurity.MaxLength = 16;
			this.textBoxSecurity.Name = "textBoxSecurity";
			this.textBoxSecurity.Size = new System.Drawing.Size(100, 20);
			this.textBoxSecurity.TabIndex = 17;
			// 
			// labelSecurity
			// 
			this.labelSecurity.AutoSize = true;
			this.labelSecurity.Location = new System.Drawing.Point(12, 39);
			this.labelSecurity.Name = "labelSecurity";
			this.labelSecurity.Size = new System.Drawing.Size(45, 13);
			this.labelSecurity.TabIndex = 16;
			this.labelSecurity.Text = "Security";
			// 
			// RecordCashDividendDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(330, 198);
			this.Controls.Add(this.textBoxSecurity);
			this.Controls.Add(this.labelSecurity);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.dateTimePickerDate);
			this.Controls.Add(this.labelDate);
			this.Controls.Add(this.textBoxValue);
			this.Controls.Add(this.labelValue);
			this.Controls.Add(this.comboBoxAccount);
			this.Controls.Add(this.labelAccount);
			this.Name = "RecordCashDividendDialog";
			this.Text = "RecordCashDividendDialog";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.DateTimePicker dateTimePickerDate;
		private System.Windows.Forms.Label labelDate;
		private System.Windows.Forms.TextBox textBoxValue;
		private System.Windows.Forms.Label labelValue;
		private System.Windows.Forms.ComboBox comboBoxAccount;
		private System.Windows.Forms.Label labelAccount;
		private System.Windows.Forms.TextBox textBoxSecurity;
		private System.Windows.Forms.Label labelSecurity;
	}
}