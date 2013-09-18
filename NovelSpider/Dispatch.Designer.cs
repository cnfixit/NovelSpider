namespace NovelSpider
{
    partial class Dispatch
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
            this.JobtabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnOK = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LVjob = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.jobCMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.移出队列ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全选ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.反选ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.清空ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ruleCMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加到队列ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全选ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.反选ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.JobtabControl.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.jobCMS.SuspendLayout();
            this.ruleCMS.SuspendLayout();
            this.SuspendLayout();
            // 
            // JobtabControl
            // 
            this.JobtabControl.Controls.Add(this.tabPage1);
            this.JobtabControl.Controls.Add(this.tabPage2);
            this.JobtabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JobtabControl.Location = new System.Drawing.Point(3, 17);
            this.JobtabControl.Name = "JobtabControl";
            this.JobtabControl.SelectedIndex = 0;
            this.JobtabControl.Size = new System.Drawing.Size(373, 390);
            this.JobtabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(365, 365);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(365, 365);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(440, 387);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "开始";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btncancel
            // 
            this.btncancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btncancel.Location = new System.Drawing.Point(560, 387);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(75, 23);
            this.btncancel.TabIndex = 1;
            this.btncancel.Text = "取消";
            this.btncancel.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.JobtabControl);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(379, 410);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "规则池：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LVjob);
            this.groupBox2.Location = new System.Drawing.Point(388, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(296, 374);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "任务队列：";
            // 
            // LVjob
            // 
            this.LVjob.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.LVjob.ContextMenuStrip = this.jobCMS;
            this.LVjob.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LVjob.FullRowSelect = true;
            this.LVjob.GridLines = true;
            this.LVjob.Location = new System.Drawing.Point(3, 17);
            this.LVjob.Name = "LVjob";
            this.LVjob.Size = new System.Drawing.Size(290, 354);
            this.LVjob.TabIndex = 0;
            this.LVjob.UseCompatibleStateImageBehavior = false;
            this.LVjob.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "序号";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "站点";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "目标地址个数";
            this.columnHeader3.Width = 165;
            // 
            // jobCMS
            // 
            this.jobCMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.移出队列ToolStripMenuItem,
            this.全选ToolStripMenuItem1,
            this.反选ToolStripMenuItem1,
            this.清空ToolStripMenuItem1});
            this.jobCMS.Name = "jobCMS";
            this.jobCMS.Size = new System.Drawing.Size(119, 92);
            // 
            // 移出队列ToolStripMenuItem
            // 
            this.移出队列ToolStripMenuItem.Name = "移出队列ToolStripMenuItem";
            this.移出队列ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.移出队列ToolStripMenuItem.Text = "移出队列";
            // 
            // 全选ToolStripMenuItem1
            // 
            this.全选ToolStripMenuItem1.Name = "全选ToolStripMenuItem1";
            this.全选ToolStripMenuItem1.Size = new System.Drawing.Size(118, 22);
            this.全选ToolStripMenuItem1.Text = "全选";
            // 
            // 反选ToolStripMenuItem1
            // 
            this.反选ToolStripMenuItem1.Name = "反选ToolStripMenuItem1";
            this.反选ToolStripMenuItem1.Size = new System.Drawing.Size(118, 22);
            this.反选ToolStripMenuItem1.Text = "反选";
            // 
            // 清空ToolStripMenuItem1
            // 
            this.清空ToolStripMenuItem1.Name = "清空ToolStripMenuItem1";
            this.清空ToolStripMenuItem1.Size = new System.Drawing.Size(118, 22);
            this.清空ToolStripMenuItem1.Text = "清空";
            // 
            // ruleCMS
            // 
            this.ruleCMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加到队列ToolStripMenuItem,
            this.全选ToolStripMenuItem,
            this.反选ToolStripMenuItem,
            this.清空ToolStripMenuItem});
            this.ruleCMS.Name = "ruleCMS";
            this.ruleCMS.Size = new System.Drawing.Size(131, 92);
            // 
            // 添加到队列ToolStripMenuItem
            // 
            this.添加到队列ToolStripMenuItem.Name = "添加到队列ToolStripMenuItem";
            this.添加到队列ToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.添加到队列ToolStripMenuItem.Text = "添加到队列";
            this.添加到队列ToolStripMenuItem.Click += new System.EventHandler(this.添加到队列ToolStripMenuItem_Click);
            // 
            // 全选ToolStripMenuItem
            // 
            this.全选ToolStripMenuItem.Name = "全选ToolStripMenuItem";
            this.全选ToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.全选ToolStripMenuItem.Text = "全选";
            this.全选ToolStripMenuItem.Click += new System.EventHandler(this.全选ToolStripMenuItem_Click);
            // 
            // 反选ToolStripMenuItem
            // 
            this.反选ToolStripMenuItem.Name = "反选ToolStripMenuItem";
            this.反选ToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.反选ToolStripMenuItem.Text = "反选";
            this.反选ToolStripMenuItem.Click += new System.EventHandler(this.反选ToolStripMenuItem_Click);
            // 
            // 清空ToolStripMenuItem
            // 
            this.清空ToolStripMenuItem.Name = "清空ToolStripMenuItem";
            this.清空ToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.清空ToolStripMenuItem.Text = "清空";
            this.清空ToolStripMenuItem.Click += new System.EventHandler(this.清空ToolStripMenuItem_Click);
            // 
            // Dispatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 418);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dispatch";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dispatch";
            this.Load += new System.EventHandler(this.Dispatch_Load);
            this.JobtabControl.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.jobCMS.ResumeLayout(false);
            this.ruleCMS.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.TabControl JobtabControl;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView LVjob;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ToolStripMenuItem 添加到队列ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全选ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清空ToolStripMenuItem;
        public System.Windows.Forms.ContextMenuStrip ruleCMS;
        private System.Windows.Forms.ToolStripMenuItem 反选ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip jobCMS;
        private System.Windows.Forms.ToolStripMenuItem 移出队列ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全选ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 反选ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 清空ToolStripMenuItem1;
    }
}