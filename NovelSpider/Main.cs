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
            initMsgBox();
            CheckForIllegalCrossThreadCalls = false;
        }

        public static ListBox MsgBox;
        /// <summary>
        /// 动态创建静态控件
        /// </summary>
        private void initMsgBox()
        {
            // 
            // MsgBox
            // 
            MsgBox = new ListBox();
            MsgBox.BackColor = System.Drawing.SystemColors.InfoText;
            MsgBox.Dock = System.Windows.Forms.DockStyle.Fill;
            MsgBox.ForeColor = System.Drawing.SystemColors.Info;
            MsgBox.ItemHeight = 12;
            MsgBox.Location = new System.Drawing.Point(3, 17);
            MsgBox.Name = "MsgBox";
            MsgBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            MsgBox.Size = new System.Drawing.Size(902, 88);
            MsgBox.TabIndex = 100;
           
            this.gbOutPut.Controls.Add(MsgBox);
        }


        private void Main_Load(object sender, EventArgs e)
        {

        }

        void ip_ChapterHasGot(object sender, ChapterEventArgs e)
        {
            Log.PrintLog("章节详情:" + e.Chapter.Name + ":" + e.Chapter.Content + "==>" + e.NovelInfo.Name);
        }

        void ip_ChapterListHasGot(object sender, ChapterListEventArgs e)
        {
            Log.PrintLog("章节列表:" + e.NovelInfo.Name);
        }

        void ip_VolumeListHasGot(object sender, VolumeListEventArgs e)
        {
            Log.PrintLog("分卷列表:" + e.NovelInfo.Name);
        }

        void ip_NovelInfoHasGot(object sender, NovelInfoEventArgs e)
        {
            Log.PrintLog("基本信息:" + e.NovelInfo.NovelChapterListUri);
        }

        void ip_NovelListHasGot(object sender, NovelListEventArgs e)
        {
            Log.PrintLog("小说列表,数量：" + e.NovelList.Count);
        }

        private void StartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Log.PrintLog("开始调度");
                Dispatch dispatch = new Dispatch();
                if (dispatch.ShowDialog() == DialogResult.OK)
                {
                    foreach (JobItem job in dispatch.Jobs)
                    {
                        IProcedure ip = Function.GetPluginInterface(job.AssemblyPath);

                        if (ip == null)
                            throw new Exception("Invalid PluginInterface.");

                        ip.NovelListHasGot += new NovelListGotEventHandler(ip_NovelListHasGot);
                        ip.NovelInfoHasGot += new NovelInfoGotEventHandler(ip_NovelInfoHasGot);
                        ip.VolumeListHasGot += new VolumeListEventHandler(ip_VolumeListHasGot);
                        ip.ChapterListHasGot += new ChapterListGotEventHandler(ip_ChapterListHasGot);
                        ip.ChapterHasGot += new ChapterGotEventHandler(ip_ChapterHasGot);

                        ip.Run(job.TargetSite);
                    }
                }
                Log.PrintLog("结束调度");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


       

    }
}
