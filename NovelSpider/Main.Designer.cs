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
            this.TestBtn = new System.Windows.Forms.Button();
            this.MsgBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // TestBtn
            // 
            this.TestBtn.Location = new System.Drawing.Point(418, 247);
            this.TestBtn.Name = "TestBtn";
            this.TestBtn.Size = new System.Drawing.Size(75, 23);
            this.TestBtn.TabIndex = 0;
            this.TestBtn.Text = "测试";
            this.TestBtn.UseVisualStyleBackColor = true;
            this.TestBtn.Click += new System.EventHandler(this.TestBtn_Click);
            // 
            // MsgBox
            // 
            this.MsgBox.FormattingEnabled = true;
            this.MsgBox.ItemHeight = 12;
            this.MsgBox.Location = new System.Drawing.Point(1, 2);
            this.MsgBox.Name = "MsgBox";
            this.MsgBox.Size = new System.Drawing.Size(501, 208);
            this.MsgBox.TabIndex = 1;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 273);
            this.Controls.Add(this.MsgBox);
            this.Controls.Add(this.TestBtn);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button TestBtn;
        private System.Windows.Forms.ListBox MsgBox;
    }
}

