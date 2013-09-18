using System;
using System.Collections.Generic;
using System.Text;

namespace NovelSpider
{
    public class JobItem
    {

        private string _AssemblyPath;
        /// <summary>
        /// 规则文件路径
        /// </summary>
        public string AssemblyPath
        {
            get { return _AssemblyPath; }
            set { _AssemblyPath = value; }
        }

        private List<Uri> _TargetSite = new List<Uri>();
        /// <summary>
        /// 目标页面
        /// </summary>
        public List<Uri> TargetSite
        {
            get { return _TargetSite; }
            set { _TargetSite = value; }
        }
    }
}
