using System;
using System.Collections.Generic;
using System.Text;

namespace NovelSpider
{
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
        public VolumeListEventArgs(List<Volume> list, NovelInfo novelinfo)
        {
            this._Volumes = list;
            this._NovelInfo = novelinfo;
        }
    }
}
