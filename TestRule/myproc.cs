using System;
using System.Collections.Generic;
using System.Text;

namespace NovelSpider
{
    public class myproc : Procedure
    {
        public myproc()
        {

        }


        protected override void InitTarget()
        {
            this.SiteName = "17看";
            this.TargetSite.Add(new Uri("http://127.0.0.1"));
            this.TargetSite.Add(new Uri("http://127.0.0.2"));
            this.TargetSite.Add(new Uri("http://127.0.0.3"));
            this.TargetSite.Add(new Uri("http://127.0.0.4"));
            this.TargetSite.Add(new Uri("http://127.0.0.5"));
            this.TargetSite.Add(new Uri("http://127.0.0.6"));
        }




        public override List<NovelInfo> GetNovelList(Uri targeturi) 
        {
            List<NovelInfo> list = new List<NovelInfo>();
            int i = 1;
            int cnt = new Random().Next(1, 5);
            for (int j = 0; j < cnt; j++)
            {
                list.Add(new NovelInfo("第" + i + "本", new Uri(targeturi + i.ToString())));
            }
            i++;
            System.Threading.Thread.Sleep(new Random().Next(1000,3000));
            System.Diagnostics.Debug.WriteLine("GetNovelList:" + targeturi);
            return list;
        }


        public override NovelInfo GetNovelInfo(Uri novelinfouri)
        {
            System.Threading.Thread.Sleep(new Random().Next(1000, 3000));
            System.Diagnostics.Debug.WriteLine("GetNovelInfo:" + novelinfouri);
            return new NovelInfo(novelinfouri.AbsoluteUri, new Author("金庸"), NovelInfo.EnumNovelStatus.PUBLISHED, "北乔峰南慕容", new Uri("http://127.0.0.1/1.html"), new Uri("http://127.0.0.1/1/list.html"), new Uri("http://127.0.0.1/img/1.jpg"));
        }

        public override List<Volume> GetVolumes(Uri novelchapterlisturi)
        {
            int i = 0;
            List<Volume> list = new List<Volume>();
            list.Add(new Volume("第" + (i++).ToString() + "卷", new Uri("http://127.0.0.1/1")));
            list.Add(new Volume("第" + (i++).ToString() + "卷", new Uri("http://127.0.0.1/2")));
            list.Add(new Volume("第" + (i++).ToString() + "卷", new Uri("http://127.0.0.1/3")));
            System.Threading.Thread.Sleep(new Random().Next(1000, 3000));
            System.Diagnostics.Debug.WriteLine("GetVolumes:" + novelchapterlisturi);
            return list;
        }




        public override List<Chapter> GetChapterList(Uri novelchapterlisturi)
        {
            int i = 0;
            List<Chapter> list = new List<Chapter>();
            list.Add(new Chapter("第" + (i++).ToString() + "章", new Uri("http://127.0.0.1/1/1")));
            list.Add(new Chapter("第" + (i++).ToString() + "章", new Uri("http://127.0.0.1/1/2")));
            list.Add(new Chapter("第" + (i++).ToString() + "章", new Uri("http://127.0.0.1/1/3")));
            System.Threading.Thread.Sleep(new Random().Next(1000, 3000));
            System.Diagnostics.Debug.WriteLine("GetChapterList:" + novelchapterlisturi);
            return list;
        }

        public override Chapter GetChapter(Uri chapteruri)
        {
            System.Threading.Thread.Sleep(new Random().Next(1000, 3000));
            System.Diagnostics.Debug.WriteLine("GetChapter:" + chapteruri);
            return new Chapter("第一章", new Uri("http://127.0.0.1/1/1"), true, "这是一篇小说");
        }
    }
}
