namespace NovelSpider
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.gbOutPut = new System.Windows.Forms.GroupBox();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LVRemote = new System.Windows.Forms.ListView();
            this.gbRemote = new System.Windows.Forms.GroupBox();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.gblocal = new System.Windows.Forms.GroupBox();
            this.MainMenu.SuspendLayout();
            this.gbRemote.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbOutPut
            // 
            this.gbOutPut.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbOutPut.Location = new System.Drawing.Point(0, 403);
            this.gbOutPut.Name = "gbOutPut";
            this.gbOutPut.Size = new System.Drawing.Size(908, 109);
            this.gbOutPut.TabIndex = 1;
            this.gbOutPut.TabStop = false;
            this.gbOutPut.Text = "输出：";
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(908, 24);
            this.MainMenu.TabIndex = 3;
            this.MainMenu.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StartToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // StartToolStripMenuItem
            // 
            this.StartToolStripMenuItem.Name = "StartToolStripMenuItem";
            this.StartToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.StartToolStripMenuItem.Text = "开始";
            this.StartToolStripMenuItem.Click += new System.EventHandler(this.StartToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // LVRemote
            // 
            this.LVRemote.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.LVRemote.Dock = System.Windows.Forms.DockStyle.Left;
            this.LVRemote.FullRowSelect = true;
            this.LVRemote.GridLines = true;
            this.LVRemote.Location = new System.Drawing.Point(3, 17);
            this.LVRemote.Name = "LVRemote";
            this.LVRemote.Size = new System.Drawing.Size(269, 359);
            this.LVRemote.TabIndex = 0;
            this.LVRemote.UseCompatibleStateImageBehavior = false;
            this.LVRemote.View = System.Windows.Forms.View.Details;
            // 
            // gbRemote
            // 
            this.gbRemote.Controls.Add(this.LVRemote);
            this.gbRemote.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbRemote.Location = new System.Drawing.Point(0, 24);
            this.gbRemote.Name = "gbRemote";
            this.gbRemote.Size = new System.Drawing.Size(521, 379);
            this.gbRemote.TabIndex = 0;
            this.gbRemote.TabStop = false;
            this.gbRemote.Text = "远程数据:";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "书名";
            this.columnHeader1.Width = 98;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "最新章节";
            this.columnHeader2.Width = 156;
            // 
            // gblocal
            // 
            this.gblocal.Dock = System.Windows.Forms.DockStyle.Right;
            this.gblocal.Location = new System.Drawing.Point(527, 24);
            this.gblocal.Name = "gblocal";
            this.gblocal.Size = new System.Drawing.Size(381, 379);
            this.gblocal.TabIndex = 4;
            this.gblocal.TabStop = false;
            this.gblocal.Text = "本地数据";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 512);
            this.Controls.Add(this.gblocal);
            this.Controls.Add(this.gbRemote);
            this.Controls.Add(this.gbOutPut);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NovelSpider";
            this.Load += new System.EventHandler(this.Main_Load);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.gbRemote.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbOutPut;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ListView LVRemote;
        private System.Windows.Forms.GroupBox gbRemote;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox gblocal;
        
    }
}

