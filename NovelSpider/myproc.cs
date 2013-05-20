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
            this.TargetSite.Add("17k", new Uri("http://127.0.0.1"));
            this.TargetSite.Add("13k", new Uri("http://127.0.0.1"));
        }




        public override List<NovelInfo> GetNovelList(Uri targeturi) 
        {
            List<NovelInfo> list = new List<NovelInfo>();
            list.Add(new NovelInfo("天龙八部", new Uri("http://127.0.0.1/1.html")));
            list.Add(new NovelInfo("神雕侠侣", new Uri("http://127.0.0.1/2.html")));
            return list;
        }


        public override NovelInfo GetNovelInfo(Uri novelinfouri)
        {
            return new NovelInfo("天龙八部", new Author("金庸"), NovelInfo.EnumNovelStatus.PUBLISHED, "北乔峰南慕容", new Uri("http://127.0.0.1/1.html"), new Uri("http://127.0.0.1/1/list.html"), new Uri("http://127.0.0.1/img/1.jpg"));
        }

        public override List<Volume> GetVolumes(Uri novelchapterlisturi)
        {
            int i = 0;
            List<Volume> list = new List<Volume>();
            list.Add(new Volume("第" + (i++).ToString() + "卷", new Uri("http://127.0.0.1/1")));
            list.Add(new Volume("第" + (i++).ToString() + "卷", new Uri("http://127.0.0.1/2")));
            list.Add(new Volume("第" + (i++).ToString() + "卷", new Uri("http://127.0.0.1/3")));
            return list;
        }




        public override List<Chapter> GetChapterList(Uri novelchapterlisturi)
        {
            int i = 0;
            List<Chapter> list = new List<Chapter>();
            list.Add(new Chapter("第" + (i++).ToString() + "章", new Uri("http://127.0.0.1/1/1")));
            list.Add(new Chapter("第" + (i++).ToString() + "章", new Uri("http://127.0.0.1/1/2")));
            list.Add(new Chapter("第" + (i++).ToString() + "章", new Uri("http://127.0.0.1/1/3")));
            return list;
        }

        public override Chapter GetChapter(Uri chapteruri)
        {
            return new Chapter("第一章", new Uri("http://127.0.0.1/1/1"), true, "这是一篇小说");
        }
    }
}
