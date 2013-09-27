using System;
using System.Collections.Generic;
using System.Text;

namespace NovelSpider
{
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
        public ChapterEventArgs(Chapter chatper, NovelInfo novelinfo)
        {
            this._Chapter = chatper;
            this._NovelInfo = novelinfo;
        }
    }
}
