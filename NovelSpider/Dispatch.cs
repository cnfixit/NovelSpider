using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace NovelSpider
{
    public partial class Dispatch : Form
    {
        public Dispatch()
        {
            InitializeComponent();
        }

        private List<JobItem> _Jobs = new List<JobItem>();
        /// <summary>
        /// 队列任务
        /// </summary>
        public List<JobItem> Jobs
        {
            get { return _Jobs; }
            set { _Jobs = value; }
        }

        

        private void Dispatch_Load(object sender, EventArgs e)
        {
            this._Jobs.Clear();
            try
            {
                string path = Application.StartupPath + @"\Rules\";
                string[] files = Directory.GetFiles(path, "*.dll");
                
               
                this.JobtabControl.TabPages.Clear();
                foreach (string s in files)
                {
                    string sitename = Function.GetTargetSiteName(s);
                    TabPage tp = new TabPage(sitename);
                    ListView lv = null;
                    if (!string.IsNullOrEmpty(sitename))
                    {
                        this.JobtabControl.TabPages.Add(tp);
                        lv = new ListView();
                        lv.Scrollable = true;
                        lv.Width = this.JobtabControl.Width - 6;
                        lv.Height = this.JobtabControl.Height;
                        lv.View = View.Details;
                        lv.FullRowSelect = true;
                        lv.GridLines = true;
                        lv.CheckBoxes = true;
                        
                        lv.ContextMenuStrip = this.ruleCMS;
                        ColumnHeader ch = new ColumnHeader();
                        ch.Width = (int)(this.JobtabControl.Width * 0.2) - 1;
                        ch.Text = "站点";
                        lv.Columns.Add(ch);
                        ColumnHeader ch2 = new ColumnHeader();
                        ch2.Width = (int)(this.JobtabControl.Width * 0.8) - 1;
                        ch2.Text = "目标地址";
                        lv.Columns.Add(ch2);

                        ColumnHeader ch3 = new ColumnHeader();
                        ch3.Width = 0;
                        ch3.Text = "规则文件";
                        lv.Columns.Add(ch3);

                        tp.Controls.Add(lv);

                        lv.ItemChecked += new ItemCheckedEventHandler(lv_ItemChecked);
                    }
                    else
                        continue;
                    List<Uri> targetsite = Function.GetTargetSiteList(s);
                    if (targetsite != null && targetsite.Count > 0)
                    {
                        foreach (Uri uri in targetsite)
                        {

                            string[] items = { sitename, uri.AbsoluteUri,s};
                            lv.Items.Add(new ListViewItem(items));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        void lv_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            e.Item.Selected = e.Item.Checked;
        }

 

   
    

        private void 添加到队列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListView lv = this.JobtabControl.SelectedTab.Controls[0] as ListView;
            if (lv.CheckedItems.Count == 0)
                return;
            JobItem job = new JobItem();
            string sitename = string.Empty;
            foreach (ListViewItem lvi in lv.CheckedItems)
            {
                job.AssemblyPath = lvi.SubItems[2].Text;
                job.TargetSite.Add(new Uri(lvi.SubItems[1].Text));
                sitename = lvi.SubItems[0].Text;
            }

            string[] item = { this.LVjob.Items.Count.ToString(), sitename,job.TargetSite.Count.ToString()};
            this.LVjob.Items.Add(new ListViewItem(item));
            this.LVjob.Items[this.LVjob.Items.Count - 1].Tag = job;
        }

        private void 全选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListView lv = this.JobtabControl.SelectedTab.Controls[0] as ListView;
            foreach (ListViewItem lvi in lv.Items)
            {
                lvi.Checked = true;
                lvi.Selected = true;
            }
        }

        private void 反选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListView lv = this.JobtabControl.SelectedTab.Controls[0] as ListView;
            foreach (ListViewItem lvi in lv.Items)
            {
                if(lv.SelectedItems.Contains(lvi))
                {
                    lvi.Selected = false;
                    lvi.Checked = false;
                }
                else
                {
                    lvi.Checked = true;
                    lvi.Selected = true;
                }
            }
        }


        private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListView lv = this.JobtabControl.SelectedTab.Controls[0] as ListView;
            foreach (ListViewItem lvi in lv.Items)
            {
                lvi.Checked = false;
                lvi.Selected = false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in LVjob.Items)
            {
                this._Jobs.Add(lvi.Tag as JobItem);
            }
        }


       
    }
}
