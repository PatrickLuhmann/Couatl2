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
			this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabSummary = new System.Windows.Forms.TabPage();
			this.panelAccountValueChart = new System.Windows.Forms.Panel();
			this.labelAccountValue = new System.Windows.Forms.Label();
			this.panelPerformanceGraph = new System.Windows.Forms.Panel();
			this.labelPerformance = new System.Windows.Forms.Label();
			this.panelAccountList = new System.Windows.Forms.Panel();
			this.labelAccountList = new System.Windows.Forms.Label();
			this.dataGridViewAccountList = new System.Windows.Forms.DataGridView();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.label2 = new System.Windows.Forms.Label();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.label3 = new System.Windows.Forms.Label();
			this.MainMenuStrip.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabSummary.SuspendLayout();
			this.panelAccountValueChart.SuspendLayout();
			this.panelPerformanceGraph.SuspendLayout();
			this.panelAccountList.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewAccountList)).BeginInit();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.SuspendLayout();
			// 
			// MainMenuStrip
			// 
			this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
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
			this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.newToolStripMenuItem.Text = "New";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.openToolStripMenuItem.Text = "Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// closeToolStripMenuItem
			// 
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.closeToolStripMenuItem.Text = "Close";
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
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
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.aboutToolStripMenuItem.Text = "About";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabSummary);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tabControl1.Location = new System.Drawing.Point(0, 24);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1003, 769);
			this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			this.tabControl1.TabIndex = 1;
			// 
			// tabSummary
			// 
			this.tabSummary.Controls.Add(this.panelAccountValueChart);
			this.tabSummary.Controls.Add(this.panelPerformanceGraph);
			this.tabSummary.Controls.Add(this.panelAccountList);
			this.tabSummary.Location = new System.Drawing.Point(4, 32);
			this.tabSummary.Name = "tabSummary";
			this.tabSummary.Padding = new System.Windows.Forms.Padding(3);
			this.tabSummary.Size = new System.Drawing.Size(995, 733);
			this.tabSummary.TabIndex = 0;
			this.tabSummary.Text = "Summary";
			this.tabSummary.UseVisualStyleBackColor = true;
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
			this.dataGridViewAccountList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewAccountList.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.dataGridViewAccountList.Location = new System.Drawing.Point(0, 30);
			this.dataGridViewAccountList.Name = "dataGridViewAccountList";
			this.dataGridViewAccountList.ReadOnly = true;
			this.dataGridViewAccountList.Size = new System.Drawing.Size(461, 688);
			this.dataGridViewAccountList.TabIndex = 0;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.label2);
			this.tabPage2.Location = new System.Drawing.Point(4, 32);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(995, 733);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Account";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(7, 7);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(68, 23);
			this.label2.TabIndex = 0;
			this.label2.Text = "label2";
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.label3);
			this.tabPage3.Location = new System.Drawing.Point(4, 32);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(995, 733);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Security";
			this.tabPage3.UseVisualStyleBackColor = true;
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
			// MainGui
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1003, 793);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.MainMenuStrip);
			this.Name = "MainGui";
			this.Text = "Couatl2";
			this.MainMenuStrip.ResumeLayout(false);
			this.MainMenuStrip.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabSummary.ResumeLayout(false);
			this.panelAccountValueChart.ResumeLayout(false);
			this.panelAccountValueChart.PerformLayout();
			this.panelPerformanceGraph.ResumeLayout(false);
			this.panelPerformanceGraph.PerformLayout();
			this.panelAccountList.ResumeLayout(false);
			this.panelAccountList.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewAccountList)).EndInit();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
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
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabSummary;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Panel panelAccountValueChart;
		private System.Windows.Forms.Label labelAccountValue;
		private System.Windows.Forms.Panel panelPerformanceGraph;
		private System.Windows.Forms.Label labelPerformance;
		private System.Windows.Forms.Panel panelAccountList;
		private System.Windows.Forms.Label labelAccountList;
		private System.Windows.Forms.DataGridView dataGridViewAccountList;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
	}
}

