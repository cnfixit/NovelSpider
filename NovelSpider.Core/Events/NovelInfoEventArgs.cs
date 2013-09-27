using System;
using System.Collections.Generic;
using System.Text;

namespace NovelSpider
{
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
}
