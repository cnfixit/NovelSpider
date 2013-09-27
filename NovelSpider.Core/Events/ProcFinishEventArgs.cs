using System;
using System.Collections.Generic;
using System.Text;

namespace NovelSpider
{
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
