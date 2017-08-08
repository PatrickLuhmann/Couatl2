namespace Couatl2
{
	partial class PurchaseTransactionDialog
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
			this.components = new System.ComponentModel.Container();
			this.label1 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.SymbolTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.QuantityTextBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.CostTextBox = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.DatePicker = new System.Windows.Forms.DateTimePicker();
			this.label5 = new System.Windows.Forms.Label();
			this.SaveButton = new System.Windows.Forms.Button();
			this.CancelButton = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.CommissionTextBox = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.SymbolNameTextBox = new System.Windows.Forms.TextBox();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(14, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(47, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Account";
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(87, 13);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(200, 21);
			this.comboBox1.TabIndex = 1;
			// 
			// SymbolTextBox
			// 
			this.SymbolTextBox.Location = new System.Drawing.Point(87, 41);
			this.SymbolTextBox.Name = "SymbolTextBox";
			this.SymbolTextBox.Size = new System.Drawing.Size(50, 20);
			this.SymbolTextBox.TabIndex = 2;
			this.SymbolTextBox.Leave += new System.EventHandler(this.SymbolTextBox_Leave);
			this.SymbolTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.SymbolTextBox_Validating);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(14, 44);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(41, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Symbol";
			// 
			// QuantityTextBox
			// 
			this.QuantityTextBox.Location = new System.Drawing.Point(87, 68);
			this.QuantityTextBox.Name = "QuantityTextBox";
			this.QuantityTextBox.Size = new System.Drawing.Size(100, 20);
			this.QuantityTextBox.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(15, 71);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(46, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Quantity";
			// 
			// CostTextBox
			// 
			this.CostTextBox.Location = new System.Drawing.Point(87, 95);
			this.CostTextBox.Name = "CostTextBox";
			this.CostTextBox.Size = new System.Drawing.Size(100, 20);
			this.CostTextBox.TabIndex = 5;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(15, 98);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(55, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "Total Cost";
			// 
			// DatePicker
			// 
			this.DatePicker.Location = new System.Drawing.Point(87, 147);
			this.DatePicker.Name = "DatePicker";
			this.DatePicker.Size = new System.Drawing.Size(200, 20);
			this.DatePicker.TabIndex = 7;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(15, 153);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(30, 13);
			this.label5.TabIndex = 9;
			this.label5.Text = "Date";
			// 
			// SaveButton
			// 
			this.SaveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.SaveButton.Location = new System.Drawing.Point(50, 194);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new System.Drawing.Size(75, 23);
			this.SaveButton.TabIndex = 8;
			this.SaveButton.Text = "Save";
			this.SaveButton.UseVisualStyleBackColor = true;
			// 
			// CancelButton
			// 
			this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelButton.Location = new System.Drawing.Point(158, 194);
			this.CancelButton.Name = "CancelButton";
			this.CancelButton.Size = new System.Drawing.Size(75, 23);
			this.CancelButton.TabIndex = 9;
			this.CancelButton.Text = "Cancel";
			this.CancelButton.UseVisualStyleBackColor = true;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(15, 124);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(62, 13);
			this.label6.TabIndex = 12;
			this.label6.Text = "Commission";
			// 
			// CommissionTextBox
			// 
			this.CommissionTextBox.Location = new System.Drawing.Point(87, 121);
			this.CommissionTextBox.Name = "CommissionTextBox";
			this.CommissionTextBox.Size = new System.Drawing.Size(100, 20);
			this.CommissionTextBox.TabIndex = 6;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(143, 44);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(35, 13);
			this.label7.TabIndex = 14;
			this.label7.Text = "Name";
			// 
			// SymbolNameTextBox
			// 
			this.SymbolNameTextBox.Location = new System.Drawing.Point(184, 41);
			this.SymbolNameTextBox.Name = "SymbolNameTextBox";
			this.SymbolNameTextBox.Size = new System.Drawing.Size(103, 20);
			this.SymbolNameTextBox.TabIndex = 3;
			// 
			// errorProvider1
			// 
			this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
			this.errorProvider1.ContainerControl = this;
			// 
			// PurchaseTransactionDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(319, 241);
			this.Controls.Add(this.SymbolNameTextBox);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.CommissionTextBox);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.CancelButton);
			this.Controls.Add(this.SaveButton);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.DatePicker);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.CostTextBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.QuantityTextBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.SymbolTextBox);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.label1);
			this.Name = "PurchaseTransactionDialog";
			this.Text = "PurchaseTransactionDialog";
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.TextBox SymbolTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox QuantityTextBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox CostTextBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DateTimePicker DatePicker;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.Button CancelButton;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox CommissionTextBox;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox SymbolNameTextBox;
		private System.Windows.Forms.ErrorProvider errorProvider1;
	}
}