using System;
using System.Collections.Generic;
using System.Text;

namespace NovelSpider
{
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
        public ChapterListEventArgs(List<Chapter> list, NovelInfo novelinfo)
        {
            this._ChapterList = list;
            this._NovelInfo = novelinfo;
        }
    }
}
