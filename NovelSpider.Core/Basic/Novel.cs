using System;
using System.Collections.Generic;
using System.Text;

namespace NovelSpider
{
    /// <summary>
    /// 小说类
    /// </summary>
    public class Novel
    {
        private NovelInfo _NovelInfo;
        /// <summary>
        /// 小说基本信息
        /// </summary>
        public NovelInfo NovelInfo
        {
            get { return _NovelInfo; }
            set { _NovelInfo = value; }
        }

        private List<Volume> _Volumes = new List<Volume>();

        /// <summary>
        /// 分卷
        /// </summary>
        public List<Volume> Volumes
        {
            get { return _Volumes; }
            set { _Volumes = value; }
        }

        private List<Chapter> _Chapters = new List<Chapter>();
        /// <summary>
        /// 小说章节集合
        /// </summary>
        public List<Chapter> Chapters
        {
            get { return _Chapters; }
            set { _Chapters = value; }
        }

        private int _Length;
        /// <summary>
        /// 小说字数
        /// </summary>
        public int Length
        {
            get { return _Length; }
            set { _Length = value; }
        }

        private string _Remark;
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

        private object _tag;
        /// <summary>
        /// 备用字段
        /// </summary>
        public object Tag
        {
            get { return _tag; }
            set { _tag = value; }
        }
    }
}
