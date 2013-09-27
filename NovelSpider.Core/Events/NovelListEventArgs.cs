using System;
using System.Collections.Generic;
using System.Text;

namespace NovelSpider
{
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
}
