using System;
using System.Collections.Generic;
using System.Text;

namespace NovelSpider
{
    /// <summary>
    /// 章节类
    /// </summary>
    public class Chapter
    {
        private NovelInfo _NovelInfo;
        /// <summary>
        /// 章节相关小说嘻嘻
        /// </summary>
        public NovelInfo NovelInfo
        {
            get { return _NovelInfo; }
            set { _NovelInfo = value; }
        }

        private string _Name;
        /// <summary>
        /// 章名
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private Uri _ChapterUri;
        /// <summary>
        /// 章地址
        /// </summary>
        public Uri ChapterUri
        {
            get { return _ChapterUri; }
            set { _ChapterUri = value; }
        }

        private int _ChapterID;
        /// <summary>
        /// 章节ID
        /// </summary>
        public int ChapterID
        {
            get { return _ChapterID; }
            set { _ChapterID = value; }
        }

        private bool _IsVip;
        /// <summary>
        /// 是否vip章节
        /// </summary>
        public bool IsVip
        {
            get { return _IsVip; }
            set { _IsVip = value; }
        }

        private string _Content;
        /// <summary>
        /// 内容
        /// </summary>
        public string Content
        {
            get { return _Content; }
            set { _Content = value; }
        }

        private int _Length;
        /// <summary>
        /// 章节字数
        /// </summary>
        public int Length
        {
            get { return _Length; }
            set { _Length = value; }
        }

        private Volume _Volume;
        /// <summary>
        /// 属于分卷
        /// </summary>
        public Volume Volume
        {
            get { return _Volume; }
            set { _Volume = value; }
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

        /// <summary>
        /// 默认空构造函数
        /// </summary>
        public Chapter() { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">章名</param>
        /// <param name="chapteruri">章地址</param>
        public Chapter(string name, Uri chapteruri)
        {
            this._Name = name;
            this._ChapterUri = chapteruri;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">章名</param>
        /// <param name="chapteruri">章地址</param>
        /// <param name="novelinfo">相关小说信息</param>
        public Chapter (string name,Uri chapteruri,NovelInfo novelinfo)
        {
            this._Name = name;
            this._ChapterUri = chapteruri;
            this._NovelInfo = novelinfo;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">章名</param>
        /// <param name="chapteruri">章地址</param>
        /// <param name="isvip">是否vip章节</param>
        public Chapter(string name, Uri chapteruri,bool isvip)
        {
            this._Name = name;
            this._ChapterUri = chapteruri;
            this._IsVip = isvip;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">章名</param>
        /// <param name="chapteruri">章地址</param>
        /// <param name="isvip">是否vip</param>
        /// <param name="content">内容</param>
        public Chapter(string name, Uri chapteruri, bool isvip,string content)
        {
            this._Name = name;
            this._ChapterUri = chapteruri;
            this._IsVip = isvip;
            this._Content = content;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">章名</param>
        /// <param name="chapteruri">章地址</param>
        /// <param name="isvip">是否vip</param>
        /// <param name="content">内容</param>
        /// <param name="remark">备注</param>
        public Chapter(string name, Uri chapteruri, bool isvip, string content,string remark)
        {
            this._Name = name;
            this._ChapterUri = chapteruri;
            this._IsVip = isvip;
            this._Content = content;
            this._Remark = remark;
        }

    }
}
