using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Threading;

namespace NovelSpider
{
    /// <summary>
    /// 重写InitTarget方法以初始化地址列表
    /// </summary>
    public abstract class Procedure:IProcedure
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public Procedure()
        {
            this._TargetSite.Clear();
            this.InitTarget();
            if (this._TargetSite.Count == 0 || string.IsNullOrEmpty(this._SiteName))
                throw new Exception("目标地址列表必须包含至少一项,目标站点名称不能为空！");
        }

        private string _SiteName = string.Empty;
        /// <summary>
        /// 站点名称
        /// </summary>
        public string SiteName
        {
            get { return _SiteName; }
            set { _SiteName = value; }
        }


        private List<Uri> _TargetSite = new List<Uri>();
        /// <summary>
        /// 目标地址集合
        /// </summary>
        public List<Uri> TargetSite
        {
            get { return _TargetSite; }
            set { _TargetSite = value; }
        }
        

        private List<Novel>[] _Novels = null;

        /// <summary>
        /// 派生类必须重写此方法以初始化目标地址列表
        /// 使用this.TargetSite.Add("目标站名称",new Uri("http://127.0.0.1/目标页面地址"));
        /// </summary>
        protected virtual void InitTarget(){}
        /// <summary>
        /// 派生类必须重写此方法以实现采集目标页面小说地址列表
        /// 返回小说基本信息集合，须至少初始化NovelInfo对象的Name和NovelUri属性
        /// 添加泛型List实例并返回
        /// </summary>
        /// <param name="targeturi">目标地址,可直接使用</param>
        /// <returns></returns>
        public abstract List<NovelInfo> GetNovelList(Uri targeturi);
        /// <summary>
        /// 派生类必须重写此方法以获取小说信息,必须初始化小说章节列表uri参数NovelChapterListUri
        /// </summary>
        /// <returns>NovelInfo类实例</returns>
        public abstract NovelInfo GetNovelInfo(Uri novelinfouri);

        /// <summary>
        /// 派生类必须重写此方法以获取小说分卷信息
        /// </summary>
        /// <param name="novelchapterlisturi"></param>
        /// <returns></returns>
        public abstract List<Volume> GetVolumes(Uri novelchapterlisturi);
        /// <summary>
        /// 派生类必须重写此方法以获取小说章节信息
        /// </summary>
        /// <returns></returns>
        public abstract List<Chapter> GetChapterList(Uri novelchapterlisturi);
        /// <summary>
        /// 获取章节内容
        /// </summary>
        /// <returns></returns>
        public abstract Chapter GetChapter(Uri chapteruri);

        /// <summary>
        /// 运行整个过程
        /// </summary>
        private void RunAll(object obj)
        {
            DateTime start = DateTime.Now;
            m.WaitOne();
            List<Uri> targetsites = obj as List<Uri>;
            _Novels = new List<Novel>[targetsites.Count];
            List<NovelInfo> NovelInfoList = null;
            for (int i = 0; i < targetsites.Count; i++)//目标页面循环
            {
                _Novels[i] = new List<Novel>();
                Novel novel = new Novel();
                NovelInfoList = GetNovelList(targetsites[i]);
                //获取小说列表名称和uri信息
                if (NovelInfoList != null && NovelListHasGot != null)
                    NovelListHasGot(this, new NovelListEventArgs(NovelInfoList));

                for (int j = 0; j < NovelInfoList.Count; j++)//每个页面的小说列表
                {
                    novel.NovelInfo = GetNovelInfo(NovelInfoList[j].NovelUri);//每个小说的基本信息
                    if (novel.NovelInfo != null)
                    {
                        if (novel.NovelInfo.NovelChapterListUri == null)
                        {
                            throw new Exception("小说基本信息获取失败，过程中止!");
                        }
                        else if (NovelInfoHasGot != null)
                        {
                            NovelInfoHasGot(this, new NovelInfoEventArgs(novel.NovelInfo));
                        }
                    }
#if debug
                    System.Diagnostics.Debug.WriteLine(novel.NovelInfo.Name);
#endif

                    //每个小说的分卷信息
                    novel.Volumes = GetVolumes(NovelInfoList[j].NovelChapterListUri);
                    if (novel.Volumes != null && VolumeListHasGot != null)
                        VolumeListHasGot(this, new VolumeListEventArgs(novel.Volumes,novel.NovelInfo));

                    //每个小说的章节信息
                    novel.Chapters = GetChapterList(NovelInfoList[j].NovelChapterListUri);
                    if (novel.Chapters != null && ChapterListHasGot != null)
                        ChapterListHasGot(this, new ChapterListEventArgs(novel.Chapters, novel.NovelInfo));


                    for (int k = 0; k < novel.Chapters.Count; k++)
                    {
                        if (novel.Chapters[k].ChapterUri == null)
                        {
                            throw new Exception("小说章节地址为空，采集失败!");
                            //continue;
                        }
                        novel.Chapters[k] = GetChapter(novel.Chapters[k].ChapterUri);
                        if (novel.Chapters[k] != null && ChapterHasGot != null)
                            ChapterHasGot(this, new ChapterEventArgs(novel.Chapters[k],novel.NovelInfo));
                    }

                    _Novels[i].Add(novel);
                }
                i++;
            }
            m.ReleaseMutex();
            //线程结束事件
            if (ProcedureHasFinished != null)
                ProcedureHasFinished(this, new ProcFinishEventArgs(DateTime.Now - start));
        }

        private Mutex m = new Mutex(false,"novel");

        /// <summary>
        /// 如非必要请勿重写此方法
        /// </summary>
        public virtual void Run(List<Uri> targetsites)
        {
            Thread t = new Thread(new ParameterizedThreadStart(RunAll));
            t.Start(targetsites);
        }

        private void _RunGetNovelList(Uri targeturi)
        {
            List<NovelInfo> NovelInfoList = GetNovelList(targeturi);
            //获取小说列表名称和uri信息
            if (NovelInfoList != null && NovelListHasGot != null)
                NovelListHasGot(this, new NovelListEventArgs(NovelInfoList));
        }
        /// <summary>
        /// 单步运行获取目标页面小说列表过程
        /// </summary>
        /// <param name="targeturi"></param>
        public virtual void RunGetNovelList(Uri targeturi)
        {
            _RunGetNovelList(targeturi);
        }

        private void _RunGetNoveInfo(Uri novelinfouri)
        {
            NovelInfo ni = GetNovelInfo(novelinfouri);//每个小说的基本信息
            if (ni != null)
            {
                if (ni.NovelChapterListUri == null)
                {
                    throw new Exception("小说基本信息获取失败，过程中止!");
                }
                else if (NovelInfoHasGot != null)
                {
                    NovelInfoHasGot(this, new NovelInfoEventArgs(ni));
                }
            }
        }
        /// <summary>
        /// 单步运行获取小说基本信息过程
        /// </summary>
        /// <param name="novelinfouri"></param>
        public virtual void RunGetNoveInfo(Uri novelinfouri)
        {
            _RunGetNoveInfo(novelinfouri);
        }

        private void _RunGetVolumes(Uri novelchapterlisturi)
        {
            List<Volume> Volumes = GetVolumes(novelchapterlisturi);
            if (Volumes != null && VolumeListHasGot != null)
                VolumeListHasGot(this, new VolumeListEventArgs(Volumes));
        }
        /// <summary>
        /// 单步运行获取小说分卷信息过程
        /// </summary>
        /// <param name="novelchapterlisturi"></param>
        public virtual void RunGetVolumes(Uri novelchapterlisturi)
        {
            _RunGetVolumes(novelchapterlisturi);
        }

        private void _RunGetChapterList(Uri novelchapterlisturi)
        {
            List<Chapter> Chapters = GetChapterList(novelchapterlisturi);
            if (Chapters != null && ChapterListHasGot != null)
                ChapterListHasGot(this, new ChapterListEventArgs(Chapters));
        }
        /// <summary>
        /// 单步运行采集小说章节列表信息过程
        /// </summary>
        /// <param name="novelchapterlisturi"></param>
        public virtual void RunGetChapterList(Uri novelchapterlisturi)
        {
            _RunGetChapterList(novelchapterlisturi);
        }

        private void _RunGetChapter(Uri chapteruri)
        {
            Chapter chapter = GetChapter(chapteruri);
            if (chapter != null && ChapterHasGot != null)
                ChapterHasGot(this, new ChapterEventArgs(chapter));
        }

        /// <summary>
        /// 单步运行获取文章内容过程
        /// </summary>
        /// <param name="chapteruri"></param>
        public virtual void RunGetChapter(Uri chapteruri)
        {
            _RunGetChapter(chapteruri);
        }
        /// <summary>
        /// 小说地址列表信息采集完成事件
        /// </summary>
        public event NovelListGotEventHandler NovelListHasGot;
        /// <summary>
        /// 小说基本信息采集完成事件
        /// </summary>
        public event NovelInfoGotEventHandler NovelInfoHasGot;
        /// <summary>
        /// 分卷信息采集完成事件
        /// </summary>
        public event VolumeListEventHandler VolumeListHasGot;
        /// <summary>
        /// 章节列表信息采集完成事件
        /// </summary>
        public event ChapterListGotEventHandler ChapterListHasGot;
        /// <summary>
        /// 章节采集完成
        /// </summary>
        public event ChapterGotEventHandler ChapterHasGot;
        /// <summary>
        /// 过程结束
        /// </summary>
        public event ProcedureFinishEventHandler ProcedureHasFinished;


    }
    /// <summary>
    /// 小说列表事件代理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void NovelListGotEventHandler(object sender,NovelListEventArgs e);
    /// <summary>
    /// 小说基本信息事件代理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void NovelInfoGotEventHandler(object sender,NovelInfoEventArgs e);
    /// <summary>
    /// 分卷信息获取事件代理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void VolumeListEventHandler(object sender,VolumeListEventArgs e);
    /// <summary>
    /// 章节列表信息获取事件代理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void ChapterListGotEventHandler(object sender, ChapterListEventArgs e);
    /// <summary>
    /// 章节内容获取事件代理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void ChapterGotEventHandler(object sender, ChapterEventArgs e);
    /// <summary>
    /// 过程结束事件代理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void ProcedureFinishEventHandler(object sender,ProcFinishEventArgs e);

    /// <summary>
    /// 过程接口
    /// </summary>
    public interface IProcedure
    {
        /// <summary>
        /// 获取小说列表
        /// </summary>
        /// <param name="targeturi">目标uri</param>
        /// <returns></returns>
        List<NovelInfo> GetNovelList(Uri targeturi);
        /// <summary>
        /// 获取小说基本信息
        /// </summary>
        /// <param name="novelinfouri"></param>
        /// <returns></returns>
        NovelInfo GetNovelInfo(Uri novelinfouri);
        /// <summary>
        /// 获取小说分卷信息
        /// </summary>
        /// <param name="novelchapterlisturi"></param>
        /// <returns></returns>
        List<Volume> GetVolumes(Uri novelchapterlisturi);
        /// <summary>
        /// 获取小说章节信息
        /// </summary>
        /// <param name="novelchapterlisturi"></param>
        /// <returns></returns>
        List<Chapter> GetChapterList(Uri novelchapterlisturi);
        /// <summary>
        /// 获取章节内容
        /// </summary>
        /// <param name="chapteruri"></param>
        /// <returns></returns>
        Chapter GetChapter(Uri chapteruri);
        /// <summary>
        /// 运行全部过程
        /// </summary>
        void Run(List<Uri> targetsites);
        /// <summary>
        /// 单步运行获取小说列表过程
        /// </summary>
        /// <param name="targeturi"></param>
        void RunGetNovelList(Uri targeturi);
        /// <summary>
        /// 单步运行获取小说基本信息过程
        /// </summary>
        /// <param name="novelinfouri"></param>
        void RunGetNoveInfo(Uri novelinfouri);
        /// <summary>
        /// 单步运行获取小说分卷信息过程
        /// </summary>
        /// <param name="novelchapterlisturi"></param>
        void RunGetVolumes(Uri novelchapterlisturi);
        /// <summary>
        /// 单步运行获取小说章节信息过程
        /// </summary>
        /// <param name="novelchapterlisturi"></param>
        void RunGetChapterList(Uri novelchapterlisturi);
        /// <summary>
        /// 单步运行获取小说内容过程
        /// </summary>
        /// <param name="chapteruri"></param>
        void RunGetChapter(Uri chapteruri);
        /// <summary>
        /// 小说列表获取完成时发生
        /// </summary>
        event NovelListGotEventHandler NovelListHasGot;
        /// <summary>
        /// 小说基本信息获取完成时发生
        /// </summary>
        event NovelInfoGotEventHandler NovelInfoHasGot;
        /// <summary>
        /// 分卷列表信息获取完成时发生
        /// </summary>
        event VolumeListEventHandler VolumeListHasGot;
        /// <summary>
        /// 章节列表获取完成时发生
        /// </summary>
        event ChapterListGotEventHandler ChapterListHasGot;
        /// <summary>
        /// 内容获取完成时发生
        /// </summary>
        event ChapterGotEventHandler ChapterHasGot;

        event ProcedureFinishEventHandler ProcedureHasFinished;
    }

    /// <summary>
    /// 小说列表事件参数类
    /// </summary>
    public class NovelListEventArgs : EventArgs
    {
        private List<NovelInfo> _NovelList = new List<NovelInfo>();
        /// <summary>
        /// 小说列表
        /// </summary>
        public List<NovelInfo> NovelList
        {
            get { return _NovelList; }
            set { _NovelList = value; }
        }
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public NovelListEventArgs() { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="list"></param>
        public NovelListEventArgs(List<NovelInfo> list)
        {
            this._NovelList = list;
        }
    }
    /// <summary>
    /// 小说基本信息事件参数类
    /// </summary>
    public class NovelInfoEventArgs : EventArgs
    {
        private NovelInfo _NovelInfo = new NovelInfo();
        /// <summary>
        /// 小说基本信息
        /// </summary>
        public NovelInfo NovelInfo
        {
            get { return _NovelInfo; }
            set { _NovelInfo = value; }
        }
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public NovelInfoEventArgs() { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="novelinfo"></param>
        public NovelInfoEventArgs(NovelInfo novelinfo)
        {
            this._NovelInfo = novelinfo;
        }

    }

    /// <summary>
    /// 分卷信息事件参数类
    /// </summary>
    public class VolumeListEventArgs : EventArgs
    {
        List<Volume> _Volumes = new List<Volume>();
        /// <summary>
        /// 分卷列表
        /// </summary>
        public List<Volume> Volumes
        {
            get { return _Volumes; }
            set { _Volumes = value; }
        }

        NovelInfo _NovelInfo = new NovelInfo();
        /// <summary>
        /// 与分卷相关章节信息
        /// </summary>
        public NovelInfo NovelInfo
        {
            get { return _NovelInfo; }
            set { _NovelInfo = value; }
        }
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public VolumeListEventArgs() { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="list">章节列表</param>
        public VolumeListEventArgs(List<Volume> list)
        {
            this._Volumes = list;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="list">章节列表</param>
        /// <param name="novelinfo">与分卷相关章节信息</param>
        public VolumeListEventArgs(List<Volume> list,NovelInfo novelinfo)
        {
            this._Volumes = list;
            this._NovelInfo = novelinfo;
        }
    }

    /// <summary>
    /// 章节列表事件参数类
    /// </summary>
    public class ChapterListEventArgs : EventArgs
    {
        List<Chapter> _ChapterList = new List<Chapter>();
        /// <summary>
        /// 章节列表
        /// </summary>
        public List<Chapter> ChapterList
        {
            get { return _ChapterList; }
            set { _ChapterList = value; }
        }

        NovelInfo _NovelInfo = new NovelInfo();
        /// <summary>
        /// 与分卷相关章节信息
        /// </summary>
        public NovelInfo NovelInfo
        {
            get { return _NovelInfo; }
            set { _NovelInfo = value; }
        }
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public ChapterListEventArgs() { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="list"></param>
        public ChapterListEventArgs(List<Chapter> list)
        {
            this._ChapterList = list;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="list"></param>
        /// <param name="novelinfo"></param>
        public ChapterListEventArgs(List<Chapter> list,NovelInfo novelinfo)
        {
            this._ChapterList = list;
            this._NovelInfo = novelinfo;
        }
    }
    /// <summary>
    /// 章节内容事件参数类
    /// </summary>
    public class ChapterEventArgs : EventArgs
    {
        Chapter _Chapter = new Chapter();
        /// <summary>
        /// 章节
        /// </summary>
        public Chapter Chapter
        {
            get { return _Chapter; }
            set { _Chapter = value; }
        }

        NovelInfo _NovelInfo = new NovelInfo();
        /// <summary>
        /// 与分卷相关章节信息
        /// </summary>
        public NovelInfo NovelInfo
        {
            get { return _NovelInfo; }
            set { _NovelInfo = value; }
        }
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public ChapterEventArgs() { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="chatper"></param>
        public ChapterEventArgs(Chapter chatper)
        {
            this._Chapter = chatper;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="chatper"></param>
        /// <param name="novelinfo"></param>
        public ChapterEventArgs(Chapter chatper,NovelInfo novelinfo)
        {
            this._Chapter = chatper;
            this._NovelInfo = novelinfo;
        }
    }

    /// <summary>
    /// 过程结束事件参数类
    /// </summary>
    public class ProcFinishEventArgs : EventArgs
    {
        TimeSpan _UsedTime = new TimeSpan();
        /// <summary>
        /// 使用时间
        /// </summary>
        public TimeSpan UsedTime
        {
            get { return _UsedTime; }
            set { _UsedTime = value; }
        }
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public ProcFinishEventArgs()
        { 
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ts"></param>
        public ProcFinishEventArgs(TimeSpan ts)
        {
            this._UsedTime = ts;
        }
    }
}
