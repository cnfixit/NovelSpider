using System;
using System.Collections.Generic;
using System.Text;

namespace NovelSpider
{
    /// <summary>
    /// 作者信息
    /// </summary>
	public class Author
	{
        private string _Name;
        /// <summary>
        /// 作者姓名
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        /// <summary>
        /// 性别枚举
        /// </summary>
        public enum EnumSex
        { 
            /// <summary>
            /// 男性
            /// </summary>
            MALE,
            /// <summary>
            /// 女性
            /// </summary>
            FEMALE,
            /// <summary>
            /// 未知
            /// </summary>
            UNKNOWN
        }

        private EnumSex _Sex;
        /// <summary>
        /// 性别
        /// </summary>
        public EnumSex Sex
        {
            get { return _Sex; }
            set { _Sex = value; }
        }

        private string _RealName;
        /// <summary>
        /// 真名
        /// </summary>
        public string RealName
        {
            get { return _RealName; }
            set { _RealName = value; }
        }

        private string _Introduction;
        /// <summary>
        /// 作者介绍
        /// </summary>
        public string Introduction
        {
            get { return _Introduction; }
            set { _Introduction = value; }
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
        /// 默认构造函数
        /// </summary>
        public Author() { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name"></param>
        public Author(string name)
        {
            this._Name = name;
        }
	}
}
