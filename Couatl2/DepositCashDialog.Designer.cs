namespace Couatl2
{
	partial class DepositCashDialog
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
			this.labelAccount = new System.Windows.Forms.Label();
			this.comboBoxAccount = new System.Windows.Forms.ComboBox();
			this.labelQuantity = new System.Windows.Forms.Label();
			this.textBoxQuantity = new System.Windows.Forms.TextBox();
			this.labelDate = new System.Windows.Forms.Label();
			this.dateTimePickerDate = new System.Windows.Forms.DateTimePicker();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// labelAccount
			// 
			this.labelAccount.AutoSize = true;
			this.labelAccount.Location = new System.Drawing.Point(14, 16);
			this.labelAccount.Name = "labelAccount";
			this.labelAccount.Size = new System.Drawing.Size(47, 13);
			this.labelAccount.TabIndex = 0;
			this.labelAccount.Text = "Account";
			// 
			// comboBoxAccount
			// 
			this.comboBoxAccount.FormattingEnabled = true;
			this.comboBoxAccount.Location = new System.Drawing.Point(85, 16);
			this.comboBoxAccount.Name = "comboBoxAccount";
			this.comboBoxAccount.Size = new System.Drawing.Size(200, 21);
			this.comboBoxAccount.TabIndex = 1;
			// 
			// labelQuantity
			// 
			this.labelQuantity.AutoSize = true;
			this.labelQuantity.Location = new System.Drawing.Point(14, 44);
			this.labelQuantity.Name = "labelQuantity";
			this.labelQuantity.Size = new System.Drawing.Size(46, 13);
			this.labelQuantity.TabIndex = 2;
			this.labelQuantity.Text = "Quantity";
			// 
			// textBoxQuantity
			// 
			this.textBoxQuantity.Location = new System.Drawing.Point(85, 46);
			this.textBoxQuantity.MaxLength = 16;
			this.textBoxQuantity.Name = "textBoxQuantity";
			this.textBoxQuantity.Size = new System.Drawing.Size(100, 20);
			this.textBoxQuantity.TabIndex = 3;
			// 
			// labelDate
			// 
			this.labelDate.AutoSize = true;
			this.labelDate.Location = new System.Drawing.Point(14, 71);
			this.labelDate.Name = "labelDate";
			this.labelDate.Size = new System.Drawing.Size(30, 13);
			this.labelDate.TabIndex = 4;
			this.labelDate.Text = "Date";
			// 
			// dateTimePickerDate
			// 
			this.dateTimePickerDate.Location = new System.Drawing.Point(85, 76);
			this.dateTimePickerDate.Name = "dateTimePickerDate";
			this.dateTimePickerDate.Size = new System.Drawing.Size(200, 20);
			this.dateTimePickerDate.TabIndex = 5;
			// 
			// buttonSave
			// 
			this.buttonSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonSave.Location = new System.Drawing.Point(59, 124);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 6;
			this.buttonSave.Text = "Save";
			this.buttonSave.UseVisualStyleBackColor = true;
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(176, 124);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 7;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// DepositCashDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(319, 261);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.dateTimePickerDate);
			this.Controls.Add(this.labelDate);
			this.Controls.Add(this.textBoxQuantity);
			this.Controls.Add(this.labelQuantity);
			this.Controls.Add(this.comboBoxAccount);
			this.Controls.Add(this.labelAccount);
			this.Name = "DepositCashDialog";
			this.Text = "DepositCashDialog";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelAccount;
		private System.Windows.Forms.ComboBox comboBoxAccount;
		private System.Windows.Forms.Label labelQuantity;
		private System.Windows.Forms.TextBox textBoxQuantity;
		private System.Windows.Forms.Label labelDate;
		private System.Windows.Forms.DateTimePicker dateTimePickerDate;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Button buttonCancel;
	}
}