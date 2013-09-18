using System;
using System.Collections.Generic;
using System.Text;

namespace NovelSpider
{
    /// <summary>
    /// 小说基本信息类
    /// </summary>
    public class NovelInfo
    {
        private string _Name;

        /// <summary>
        /// [必填]小说名称
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private Author _Author;
        /// <summary>
        /// 作者
        /// </summary>
        public Author Author
        {
            get { return _Author; }
            set { _Author = value; }
        }

        /// <summary>
        /// 小说状态枚举
        /// </summary>
        public enum EnumNovelStatus
        {
            /// <summary>
            /// 写作中
            /// </summary>
            WRITTING,
            /// <summary>
            /// 已完成
            /// </summary>
            FINISHED,
            /// <summary>
            /// 已出版
            /// </summary>
            PUBLISHED,
            /// <summary>
            /// 未知
            /// </summary>
            UNKNOWN
        }

        private EnumNovelStatus _NovelStatus;
        /// <summary>
        /// 小说状态
        /// </summary>
        public EnumNovelStatus NovelStatus
        {
            get { return _NovelStatus; }
            set { _NovelStatus = value; }
        }

        private string _Summary;
        /// <summary>
        /// 小说摘要
        /// </summary>
        public string Summary
        {
            get { return _Summary; }
            set { _Summary = value; }
        }

        private Uri _NovelUri;
        /// <summary>
        /// [必填]小说url
        /// </summary>
        public Uri NovelUri
        {
            get { return _NovelUri; }
            set { _NovelUri = value; }
        }

        private Uri _NovelChapterListUri;
        /// <summary>
        /// [必填]小说章节列表uri
        /// </summary>
        public Uri NovelChapterListUri
        {
            get { return _NovelChapterListUri; }
            set { _NovelChapterListUri = value; }
        }

        private Uri _NovelCoverUri;

        /// <summary>
        /// 小说封面url
        /// </summary>
        public Uri NovelCoverUri
        {
            get { return _NovelCoverUri; }
            set { _NovelCoverUri = value; }
        }

        private string _Source;
        /// <summary>
        /// 来源
        /// </summary>
        public string Source
        {
            get { return _Source; }
            set { _Source = value; }
        }

        private string _BigClass;
        /// <summary>
        /// 小说大分类
        /// </summary>
        public string BigClass
        {
            get { return _BigClass; }
            set { _BigClass = value; }
        }
        private string _SmallClass;
        /// <summary>
        /// 小说小分类
        /// </summary>
        public string SmallClass
        {
            get { return _SmallClass; }
            set { _SmallClass = value; }
        }

        private int _BigClassID;
        /// <summary>
        /// 大分类编号
        /// </summary>
        public int BigClassID
        {
            get { return _BigClassID; }
            set { _BigClassID = value; }
        }
        private int _SmallClassID;
        /// <summary>
        /// 小分类编号
        /// </summary>
        public int SmallClassID
        {
            get { return _SmallClassID; }
            set { _SmallClassID = value; }
        }
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public NovelInfo() { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">小说名称</param>
        /// <param name="noveluri">小说地址</param>
        public NovelInfo(string name, Uri noveluri)
        {
            this._Name = name;
            this._NovelUri = noveluri;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">小说名称</param>
        /// <param name="author">小说作者</param>
        /// <param name="status">小说状态</param>
        /// <param name="summary">小说摘要</param>
        /// <param name="noveluri">小说地址</param>
        /// <param name="novelchapterlisturi">小说章节列表地址</param>
        /// <param name="novelcoveruri">小说封面地址</param>
        public NovelInfo(string name,Author author,EnumNovelStatus status, string summary,Uri noveluri,Uri novelchapterlisturi, Uri novelcoveruri)
        {
            this._Name = name;
            this._Author = author;
            this._NovelStatus = status;
            this._Summary = summary;
            this._NovelUri = noveluri;
            this._NovelChapterListUri = novelchapterlisturi;
            this._NovelCoverUri = novelcoveruri;
        }
    }
}
