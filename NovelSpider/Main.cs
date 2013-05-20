using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Collections.ObjectModel;

using System.Threading;
using System.IO;


namespace NovelSpider
{

    


    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //test for github
        }


        
        private void TestBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Application.StartupPath + @"\Rules\";
                string[] files = Directory.GetFiles(path, "*.dll");
                ListView lv = null;
                Dispatch dispatch = new Dispatch();
                dispatch.JobtabControl.TabPages.Clear();
                foreach (string s in files)
                {
                    string sitename = GetTargetSiteName(s);
                    TabPage tp = new TabPage(sitename);
                    if (!string.IsNullOrEmpty(sitename))
                    {
                        dispatch.JobtabControl.TabPages.Add(tp);
                        lv = new ListView();
                        lv.Width = dispatch.JobtabControl.Width;
                        lv.Height = dispatch.JobtabControl.Height;
                        lv.View = View.Details;
                        lv.FullRowSelect = true;
                        lv.GridLines = true;
                        lv.CheckBoxes = true;
                        lv.Scrollable = false;
                        ColumnHeader ch = new ColumnHeader();
                        ch.Width = (int)(dispatch.JobtabControl.Width * 0.2) - 1;
                        ch.Text = "站点";
                        lv.Columns.Add(ch);
                        ColumnHeader ch2 = new ColumnHeader();
                        ch2.Width = (int)(dispatch.JobtabControl.Width * 0.8) - 1;
                        ch2.Text = "目标地址";
                        lv.Columns.Add(ch2);
                        tp.Controls.Add(lv);
                    }
                    else
                        continue;
                    List<Uri> targetsite = GetTargetSiteList(s);
                    if (targetsite != null && targetsite.Count > 0)
                    {
                        foreach (Uri uri in targetsite)
                        {
                           
                            string[] items = { sitename ,uri.AbsoluteUri};
                            lv.Items.Add(new ListViewItem(items));
                        }
                    }
                }
                dispatch.ShowDialog();

                IProcedure ip = GetPluginInterface(Application.StartupPath + @"\Rules\TestRule.dll");

                if (ip == null)
                    return;

                ip.NovelListHasGot += new NovelListGotEventHandler(ip_NovelListHasGot);
                ip.NovelInfoHasGot += new NovelInfoGotEventHandler(ip_NovelInfoHasGot);
                ip.VolumeListHasGot += new VolumeListEventHandler(ip_VolumeListHasGot);
                ip.ChapterListHasGot += new ChapterListGotEventHandler(ip_ChapterListHasGot);
                ip.ChapterHasGot += new ChapterGotEventHandler(ip_ChapterHasGot);
                ip.Run();

                

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void ip_ChapterHasGot(object sender, ChapterEventArgs e)
        {
            this.MsgBox.Items.Add(e.Chapter.Name+":"+e.Chapter.Content);
        }

        void ip_ChapterListHasGot(object sender, ChapterListEventArgs e)
        {
            foreach (Chapter chapter in e.ChapterList)
                this.MsgBox.Items.Add(chapter.Name + "," + chapter.ChapterUri.ToString());
        }

        void ip_VolumeListHasGot(object sender, VolumeListEventArgs e)
        {
            foreach (Volume vol in e.Volumes)
                this.MsgBox.Items.Add(vol.VolumeName + "," + vol.VolumeUri.ToString());
        }

        void ip_NovelInfoHasGot(object sender, NovelInfoEventArgs e)
        {
            this.MsgBox.Items.Add("章节列表地址:" + e.NovelInfo.NovelChapterListUri);
        }

        void ip_NovelListHasGot(object sender, NovelListEventArgs e)
        {
            foreach (NovelInfo ni in e.NovelList)
                this.MsgBox.Items.Add(ni.Name);
        }

        /// <summary>
        /// 获取指定动态库IProcedure实例
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        IProcedure GetPluginInterface(string filepath)
        {
            if (!File.Exists(filepath))
                return null;

            Type type = null;
            IProcedure ip = null;
            string fullname = string.Empty;

            try
            {
                Assembly ass = Assembly.LoadFile(filepath);
                Type[] tps = ass.GetTypes();


                foreach (Type t in tps)
                {
                    if (t.IsSubclassOf(typeof(Procedure)))
                    {
                        fullname = t.FullName;
                        type = t;
                        break;
                    }
                }

                if (!string.IsNullOrEmpty(fullname))
                {
                    ip = ass.CreateInstance(fullname) as IProcedure;
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

            return ip;
        }

        /// <summary>
        /// 获取指定动态库的站点名称
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        string GetTargetSiteName(string filepath)
        {
            if (!File.Exists(filepath))
                return null;

            string res = string.Empty;
            try
            {
                Assembly ass = Assembly.LoadFile(filepath);

                Type[] tps = ass.GetTypes();
                Type type = null;
                string fullname = string.Empty;
                Procedure pro = null;


                foreach (Type t in tps)
                {
                    if (t.IsSubclassOf(typeof(Procedure)))
                    {
                        fullname = t.FullName;
                        type = t;
                        break;
                    }
                }

                if (!string.IsNullOrEmpty(fullname))
                    pro = ass.CreateInstance(fullname) as Procedure;
                if (pro != null)
                    res = pro.SiteName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }


        /// <summary>
        /// 获取指定动态库的目标地址列表信息
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        List<Uri> GetTargetSiteList(string filepath)
        {
            if (!File.Exists(filepath))
                return null;

            List<Uri> res = null;
            try
            {
                Assembly ass = Assembly.LoadFile(filepath);

                Type[] tps = ass.GetTypes();
                Type type = null;
                string fullname = string.Empty;
                Procedure pro = null;


                foreach (Type t in tps)
                {
                    if (t.IsSubclassOf(typeof(Procedure)))
                    {
                        fullname = t.FullName;
                        type = t;
                        break;
                    }
                }

                if (!string.IsNullOrEmpty(fullname))
                    pro = ass.CreateInstance(fullname) as Procedure;
                if(pro != null)
                    res = pro.TargetSite;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }
    }
}
