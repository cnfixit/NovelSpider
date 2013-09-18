using System;
using System.Collections.Generic;
using System.Text;

namespace NovelSpider
{
    /// <summary>
    /// 小说分卷
    /// </summary>
    public class Volume
    {
        private NovelInfo _NovelInfo;
        /// <summary>
        /// 卷相关小说信息
        /// </summary>
        public NovelInfo NovelInfo
        {
            get { return _NovelInfo; }
            set { _NovelInfo = value; }
        }

        private string _VolumeName;
        /// <summary>
        /// 分卷名
        /// </summary>
        public string VolumeName
        {
            get { return _VolumeName; }
            set { _VolumeName = value; }
        }

        private Uri _VolumeUri;
        /// <summary>
        /// 分卷地址
        /// </summary>
        public Uri VolumeUri
        {
            get { return _VolumeUri; }
            set { _VolumeUri = value; }
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
        public Volume() { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="volumename">分卷名称</param>
        /// <param name="volumeuri">分卷地址</param>
        public Volume(string volumename, Uri volumeuri)
        {
            this._VolumeName = volumename;
            this._VolumeUri = volumeuri;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="volumename">分卷名称</param>
        /// <param name="volumeuri">分卷地址</param>
        /// <param name="novelinfo">相关小说信息</param>
        public Volume(string volumename,Uri volumeuri,NovelInfo novelinfo)
        {
            this._VolumeName = volumename;
            this._VolumeUri = volumeuri;
            this._NovelInfo = novelinfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="volumename">分卷名称</param>
        /// <param name="volumeuri">分卷地址</param>
        /// <param name="remark">分卷备注</param>
        public Volume(string volumename,Uri volumeuri,string remark)
        {
            this._VolumeName = volumename;
            this._VolumeUri = volumeuri;
            this._Remark = remark;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="volumename">分卷名称</param>
        /// <param name="volumeuri">分卷地址</param>
        /// <param name="remark">分卷备注</param>
        /// <param name="tag">分卷备用</param>
        public Volume(string volumename, Uri volumeuri, string remark,object tag)
        {
            this._VolumeName = volumename;
            this._VolumeUri = volumeuri;
            this._Remark = remark;
            this._tag = tag;
        }
    }
}
