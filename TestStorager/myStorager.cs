using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace NovelSpider
{
    public class myStorager:Storager
    {
        public myStorager()
        {
           this.MethodName = "txt";
        }
        Label lbl;
        TextBox tb;
        Button btn;

        protected override void InitConfigUI(Control con)
        {
            lbl = new Label();
            lbl.Size = new Size(70, 20);
            lbl.Location = new Point(10, 20);
            lbl.Text = "保存路径：";
            con.Controls.Add(lbl);

            tb = new TextBox();
            tb.Size = new Size(220, 20);
            tb.Location = new Point(80,17);
            con.Controls.Add(tb);

            btn = new Button();
            btn.Size = new Size(50, 20);
            btn.Location = new Point(220,45);
            btn.Text = "选择..";
            con.Controls.Add(btn);

            btn.Click += new EventHandler(btn_Click);
        }

        void btn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            if(sfd.ShowDialog() == DialogResult.OK)
            {
                tb.Text = sfd.FileName;
            }
        }


        protected override void SaveStorageConfig()
        {
            
        }


        protected override void LoadStorageConfig()
        {
             
        }

        protected override void SaveTheNovelInfo(NovelInfo novelinfo)
        {
            MessageBox.Show(novelinfo.Name);
        }

        protected override void SaveTheChapter(Chapter chapter)
        {
             
        }
    }
}
