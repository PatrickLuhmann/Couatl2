namespace Couatl2
{
	partial class MainGui
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.accountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.createAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.transactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.depositCashToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.withdrawCashToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.buySecurityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sellSecurityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.recordCashDividendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.MainTabControl = new System.Windows.Forms.TabControl();
			this.SummaryTab = new System.Windows.Forms.TabPage();
			this.panelAccountValueChart = new System.Windows.Forms.Panel();
			this.labelAccountValue = new System.Windows.Forms.Label();
			this.panelPerformanceGraph = new System.Windows.Forms.Panel();
			this.labelPerformance = new System.Windows.Forms.Label();
			this.panelAccountList = new System.Windows.Forms.Panel();
			this.labelAccountList = new System.Windows.Forms.Label();
			this.dataGridViewAccountList = new System.Windows.Forms.DataGridView();
			this.AccountTab = new System.Windows.Forms.TabPage();
			this.labelTransactions = new System.Windows.Forms.Label();
			this.AccountTransactionsView = new System.Windows.Forms.DataGridView();
			this.AccountPositionsView = new System.Windows.Forms.DataGridView();
			this.labelPositions = new System.Windows.Forms.Label();
			this.AccountComboBox = new System.Windows.Forms.ComboBox();
			this.labelAccount = new System.Windows.Forms.Label();
			this.SecurityTab = new System.Windows.Forms.TabPage();
			this.label3 = new System.Windows.Forms.Label();
			this.labelCash = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.MainMenuStrip.SuspendLayout();
			this.MainTabControl.SuspendLayout();
			this.SummaryTab.SuspendLayout();
			this.panelAccountValueChart.SuspendLayout();
			this.panelPerformanceGraph.SuspendLayout();
			this.panelAccountList.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewAccountList)).BeginInit();
			this.AccountTab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.AccountTransactionsView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.AccountPositionsView)).BeginInit();
			this.SecurityTab.SuspendLayout();
			this.SuspendLayout();
			// 
			// MainMenuStrip
			// 
			this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.accountToolStripMenuItem,
            this.transactionToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
			this.MainMenuStrip.Name = "MainMenuStrip";
			this.MainMenuStrip.Size = new System.Drawing.Size(1003, 24);
			this.MainMenuStrip.TabIndex = 0;
			this.MainMenuStrip.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.newToolStripMenuItem.Text = "New";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.openToolStripMenuItem.Text = "Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// closeToolStripMenuItem
			// 
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.closeToolStripMenuItem.Text = "Close";
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// accountToolStripMenuItem
			// 
			this.accountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createAccountToolStripMenuItem,
            this.deleteAccountToolStripMenuItem});
			this.accountToolStripMenuItem.Name = "accountToolStripMenuItem";
			this.accountToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
			this.accountToolStripMenuItem.Text = "Account";
			// 
			// createAccountToolStripMenuItem
			// 
			this.createAccountToolStripMenuItem.Name = "createAccountToolStripMenuItem";
			this.createAccountToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
			this.createAccountToolStripMenuItem.Text = "Create Account";
			this.createAccountToolStripMenuItem.Click += new System.EventHandler(this.createAccountToolStripMenuItem_Click);
			// 
			// deleteAccountToolStripMenuItem
			// 
			this.deleteAccountToolStripMenuItem.Name = "deleteAccountToolStripMenuItem";
			this.deleteAccountToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
			this.deleteAccountToolStripMenuItem.Text = "Delete Account";
			// 
			// transactionToolStripMenuItem
			// 
			this.transactionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.depositCashToolStripMenuItem,
            this.withdrawCashToolStripMenuItem,
            this.buySecurityToolStripMenuItem,
            this.sellSecurityToolStripMenuItem,
            this.recordCashDividendToolStripMenuItem});
			this.transactionToolStripMenuItem.Name = "transactionToolStripMenuItem";
			this.transactionToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
			this.transactionToolStripMenuItem.Text = "Transaction";
			// 
			// depositCashToolStripMenuItem
			// 
			this.depositCashToolStripMenuItem.Name = "depositCashToolStripMenuItem";
			this.depositCashToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
			this.depositCashToolStripMenuItem.Text = "Deposit Cash";
			this.depositCashToolStripMenuItem.Click += new System.EventHandler(this.depositCashToolStripMenuItem_Click);
			// 
			// withdrawCashToolStripMenuItem
			// 
			this.withdrawCashToolStripMenuItem.Name = "withdrawCashToolStripMenuItem";
			this.withdrawCashToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
			this.withdrawCashToolStripMenuItem.Text = "Withdraw Cash";
			// 
			// buySecurityToolStripMenuItem
			// 
			this.buySecurityToolStripMenuItem.Name = "buySecurityToolStripMenuItem";
			this.buySecurityToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
			this.buySecurityToolStripMenuItem.Text = "Buy Security";
			this.buySecurityToolStripMenuItem.Click += new System.EventHandler(this.buySecurityToolStripMenuItem_Click);
			// 
			// sellSecurityToolStripMenuItem
			// 
			this.sellSecurityToolStripMenuItem.Name = "sellSecurityToolStripMenuItem";
			this.sellSecurityToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
			this.sellSecurityToolStripMenuItem.Text = "Sell Security";
			this.sellSecurityToolStripMenuItem.Click += new System.EventHandler(this.sellSecurityToolStripMenuItem_Click);
			// 
			// recordCashDividendToolStripMenuItem
			// 
			this.recordCashDividendToolStripMenuItem.Name = "recordCashDividendToolStripMenuItem";
			this.recordCashDividendToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
			this.recordCashDividendToolStripMenuItem.Text = "Record Cash Dividend";
			this.recordCashDividendToolStripMenuItem.Click += new System.EventHandler(this.recordCashDividendToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.aboutToolStripMenuItem.Text = "About";
			// 
			// MainTabControl
			// 
			this.MainTabControl.Controls.Add(this.SummaryTab);
			this.MainTabControl.Controls.Add(this.AccountTab);
			this.MainTabControl.Controls.Add(this.SecurityTab);
			this.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainTabControl.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MainTabControl.Location = new System.Drawing.Point(0, 24);
			this.MainTabControl.Name = "MainTabControl";
			this.MainTabControl.SelectedIndex = 0;
			this.MainTabControl.Size = new System.Drawing.Size(1003, 769);
			this.MainTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			this.MainTabControl.TabIndex = 1;
			this.MainTabControl.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.MainTabControl_Selecting);
			// 
			// SummaryTab
			// 
			this.SummaryTab.Controls.Add(this.panelAccountValueChart);
			this.SummaryTab.Controls.Add(this.panelPerformanceGraph);
			this.SummaryTab.Controls.Add(this.panelAccountList);
			this.SummaryTab.Location = new System.Drawing.Point(4, 32);
			this.SummaryTab.Name = "SummaryTab";
			this.SummaryTab.Padding = new System.Windows.Forms.Padding(3);
			this.SummaryTab.Size = new System.Drawing.Size(995, 733);
			this.SummaryTab.TabIndex = 0;
			this.SummaryTab.Text = "Summary";
			this.SummaryTab.UseVisualStyleBackColor = true;
			// 
			// panelAccountValueChart
			// 
			this.panelAccountValueChart.Controls.Add(this.labelAccountValue);
			this.panelAccountValueChart.Location = new System.Drawing.Point(477, 376);
			this.panelAccountValueChart.Name = "panelAccountValueChart";
			this.panelAccountValueChart.Size = new System.Drawing.Size(510, 349);
			this.panelAccountValueChart.TabIndex = 2;
			// 
			// labelAccountValue
			// 
			this.labelAccountValue.AutoSize = true;
			this.labelAccountValue.Location = new System.Drawing.Point(6, 4);
			this.labelAccountValue.Name = "labelAccountValue";
			this.labelAccountValue.Size = new System.Drawing.Size(145, 23);
			this.labelAccountValue.TabIndex = 0;
			this.labelAccountValue.Text = "Account Value";
			// 
			// panelPerformanceGraph
			// 
			this.panelPerformanceGraph.Controls.Add(this.labelPerformance);
			this.panelPerformanceGraph.Location = new System.Drawing.Point(476, 7);
			this.panelPerformanceGraph.Name = "panelPerformanceGraph";
			this.panelPerformanceGraph.Size = new System.Drawing.Size(513, 362);
			this.panelPerformanceGraph.TabIndex = 1;
			// 
			// labelPerformance
			// 
			this.labelPerformance.AutoSize = true;
			this.labelPerformance.Location = new System.Drawing.Point(3, 4);
			this.labelPerformance.Name = "labelPerformance";
			this.labelPerformance.Size = new System.Drawing.Size(129, 23);
			this.labelPerformance.TabIndex = 0;
			this.labelPerformance.Text = "Performance";
			// 
			// panelAccountList
			// 
			this.panelAccountList.Controls.Add(this.labelAccountList);
			this.panelAccountList.Controls.Add(this.dataGridViewAccountList);
			this.panelAccountList.Location = new System.Drawing.Point(9, 7);
			this.panelAccountList.Name = "panelAccountList";
			this.panelAccountList.Size = new System.Drawing.Size(461, 718);
			this.panelAccountList.TabIndex = 0;
			// 
			// labelAccountList
			// 
			this.labelAccountList.AutoSize = true;
			this.labelAccountList.Location = new System.Drawing.Point(4, 4);
			this.labelAccountList.Name = "labelAccountList";
			this.labelAccountList.Size = new System.Drawing.Size(127, 23);
			this.labelAccountList.TabIndex = 1;
			this.labelAccountList.Text = "Account List";
			// 
			// dataGridViewAccountList
			// 
			this.dataGridViewAccountList.AllowUserToAddRows = false;
			this.dataGridViewAccountList.AllowUserToDeleteRows = false;
			this.dataGridViewAccountList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dataGridViewAccountList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewAccountList.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.dataGridViewAccountList.Location = new System.Drawing.Point(0, 30);
			this.dataGridViewAccountList.Name = "dataGridViewAccountList";
			this.dataGridViewAccountList.ReadOnly = true;
			this.dataGridViewAccountList.RowHeadersVisible = false;
			this.dataGridViewAccountList.Size = new System.Drawing.Size(461, 688);
			this.dataGridViewAccountList.TabIndex = 0;
			// 
			// AccountTab
			// 
			this.AccountTab.Controls.Add(this.label1);
			this.AccountTab.Controls.Add(this.labelCash);
			this.AccountTab.Controls.Add(this.labelTransactions);
			this.AccountTab.Controls.Add(this.AccountTransactionsView);
			this.AccountTab.Controls.Add(this.AccountPositionsView);
			this.AccountTab.Controls.Add(this.labelPositions);
			this.AccountTab.Controls.Add(this.AccountComboBox);
			this.AccountTab.Controls.Add(this.labelAccount);
			this.AccountTab.Location = new System.Drawing.Point(4, 32);
			this.AccountTab.Name = "AccountTab";
			this.AccountTab.Padding = new System.Windows.Forms.Padding(3);
			this.AccountTab.Size = new System.Drawing.Size(995, 733);
			this.AccountTab.TabIndex = 1;
			this.AccountTab.Text = "Account";
			this.AccountTab.UseVisualStyleBackColor = true;
			// 
			// labelTransactions
			// 
			this.labelTransactions.AutoSize = true;
			this.labelTransactions.Location = new System.Drawing.Point(426, 64);
			this.labelTransactions.Name = "labelTransactions";
			this.labelTransactions.Size = new System.Drawing.Size(129, 23);
			this.labelTransactions.TabIndex = 6;
			this.labelTransactions.Text = "Transactions";
			// 
			// AccountTransactionsView
			// 
			this.AccountTransactionsView.AllowUserToAddRows = false;
			this.AccountTransactionsView.AllowUserToDeleteRows = false;
			this.AccountTransactionsView.AllowUserToResizeRows = false;
			this.AccountTransactionsView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.AccountTransactionsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.AccountTransactionsView.Location = new System.Drawing.Point(430, 91);
			this.AccountTransactionsView.Name = "AccountTransactionsView";
			this.AccountTransactionsView.ReadOnly = true;
			this.AccountTransactionsView.RowHeadersVisible = false;
			this.AccountTransactionsView.Size = new System.Drawing.Size(557, 634);
			this.AccountTransactionsView.TabIndex = 5;
			// 
			// AccountPositionsView
			// 
			this.AccountPositionsView.AllowUserToAddRows = false;
			this.AccountPositionsView.AllowUserToDeleteRows = false;
			this.AccountPositionsView.AllowUserToResizeColumns = false;
			this.AccountPositionsView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.AccountPositionsView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.AccountPositionsView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
			this.AccountPositionsView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.AccountPositionsView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
			this.AccountPositionsView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(187)))), ((int)(((byte)(237)))));
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkBlue;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(187)))), ((int)(((byte)(237)))));
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.DarkBlue;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.AccountPositionsView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.AccountPositionsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(232)))), ((int)(((byte)(249)))));
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Blue;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(232)))), ((int)(((byte)(249)))));
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Blue;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.AccountPositionsView.DefaultCellStyle = dataGridViewCellStyle2;
			this.AccountPositionsView.EnableHeadersVisualStyles = false;
			this.AccountPositionsView.GridColor = System.Drawing.Color.Red;
			this.AccountPositionsView.Location = new System.Drawing.Point(10, 117);
			this.AccountPositionsView.MultiSelect = false;
			this.AccountPositionsView.Name = "AccountPositionsView";
			this.AccountPositionsView.ReadOnly = true;
			this.AccountPositionsView.RowHeadersVisible = false;
			this.AccountPositionsView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.AccountPositionsView.Size = new System.Drawing.Size(413, 608);
			this.AccountPositionsView.TabIndex = 4;
			this.AccountPositionsView.TabStop = false;
			// 
			// labelPositions
			// 
			this.labelPositions.AutoSize = true;
			this.labelPositions.Location = new System.Drawing.Point(8, 91);
			this.labelPositions.Name = "labelPositions";
			this.labelPositions.Size = new System.Drawing.Size(96, 23);
			this.labelPositions.TabIndex = 3;
			this.labelPositions.Text = "Positions";
			// 
			// AccountComboBox
			// 
			this.AccountComboBox.FormattingEnabled = true;
			this.AccountComboBox.Location = new System.Drawing.Point(110, 7);
			this.AccountComboBox.Name = "AccountComboBox";
			this.AccountComboBox.Size = new System.Drawing.Size(313, 31);
			this.AccountComboBox.TabIndex = 2;
			this.AccountComboBox.SelectedIndexChanged += new System.EventHandler(this.AccountComboBox_SelectedIndexChanged);
			// 
			// labelAccount
			// 
			this.labelAccount.AutoSize = true;
			this.labelAccount.Location = new System.Drawing.Point(6, 10);
			this.labelAccount.Name = "labelAccount";
			this.labelAccount.Size = new System.Drawing.Size(95, 23);
			this.labelAccount.TabIndex = 0;
			this.labelAccount.Text = "Account:";
			// 
			// SecurityTab
			// 
			this.SecurityTab.Controls.Add(this.label3);
			this.SecurityTab.Location = new System.Drawing.Point(4, 32);
			this.SecurityTab.Name = "SecurityTab";
			this.SecurityTab.Size = new System.Drawing.Size(995, 733);
			this.SecurityTab.TabIndex = 2;
			this.SecurityTab.Text = "Security";
			this.SecurityTab.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 4);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(68, 23);
			this.label3.TabIndex = 0;
			this.label3.Text = "label3";
			// 
			// labelCash
			// 
			this.labelCash.AutoSize = true;
			this.labelCash.Location = new System.Drawing.Point(8, 64);
			this.labelCash.Name = "labelCash";
			this.labelCash.Size = new System.Drawing.Size(56, 23);
			this.labelCash.TabIndex = 7;
			this.labelCash.Text = "Cash";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(358, 64);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 23);
			this.label1.TabIndex = 8;
			this.label1.Text = "$0.00";
			// 
			// MainGui
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1003, 793);
			this.Controls.Add(this.MainTabControl);
			this.Controls.Add(this.MainMenuStrip);
			this.Name = "MainGui";
			this.Text = "Couatl2";
			this.MainMenuStrip.ResumeLayout(false);
			this.MainMenuStrip.PerformLayout();
			this.MainTabControl.ResumeLayout(false);
			this.SummaryTab.ResumeLayout(false);
			this.panelAccountValueChart.ResumeLayout(false);
			this.panelAccountValueChart.PerformLayout();
			this.panelPerformanceGraph.ResumeLayout(false);
			this.panelPerformanceGraph.PerformLayout();
			this.panelAccountList.ResumeLayout(false);
			this.panelAccountList.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewAccountList)).EndInit();
			this.AccountTab.ResumeLayout(false);
			this.AccountTab.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.AccountTransactionsView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.AccountPositionsView)).EndInit();
			this.SecurityTab.ResumeLayout(false);
			this.SecurityTab.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip MainMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.TabControl MainTabControl;
		private System.Windows.Forms.TabPage SummaryTab;
		private System.Windows.Forms.TabPage AccountTab;
		private System.Windows.Forms.TabPage SecurityTab;
		private System.Windows.Forms.Panel panelAccountValueChart;
		private System.Windows.Forms.Label labelAccountValue;
		private System.Windows.Forms.Panel panelPerformanceGraph;
		private System.Windows.Forms.Label labelPerformance;
		private System.Windows.Forms.Panel panelAccountList;
		private System.Windows.Forms.Label labelAccountList;
		private System.Windows.Forms.DataGridView dataGridViewAccountList;
		private System.Windows.Forms.Label labelAccount;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DataGridView AccountPositionsView;
		private System.Windows.Forms.Label labelPositions;
		private System.Windows.Forms.ComboBox AccountComboBox;
		private System.Windows.Forms.ToolStripMenuItem accountToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem createAccountToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteAccountToolStripMenuItem;
		private System.Windows.Forms.Label labelTransactions;
		private System.Windows.Forms.DataGridView AccountTransactionsView;
		private System.Windows.Forms.ToolStripMenuItem transactionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem depositCashToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem withdrawCashToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem buySecurityToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sellSecurityToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem recordCashDividendToolStripMenuItem;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label labelCash;
	}
}

