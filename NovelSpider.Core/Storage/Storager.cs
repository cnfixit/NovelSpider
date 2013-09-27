using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace NovelSpider
{
    /// <summary>
    /// 抽象存储类，负责保存、生成采集到的内容
    /// </summary>
    public abstract class Storager:IStorager
    {


        /// <summary>
        /// 默认构造函数
        /// </summary>
        public Storager()
        {
            if (string.IsNullOrEmpty(this._MethodName))
                this._MethodName = "unknown";
        }

        private string _MethodName = string.Empty;
        /// <summary>
        /// 方法名称
        /// </summary>
        public string MethodName
        {
            get { return _MethodName; }
            set { _MethodName = value; }
        }

        /// <summary>
        /// 初始化UI，供主程序调用
        /// </summary>
        public  void InitUI(Control con) 
        {
            InitConfigUI(con);
        }
        /// <summary>
        /// 初始化UI，派生类重写此方法以获得不同的UI
        /// </summary>
        /// <param name="con"></param>
        protected virtual void InitConfigUI(Control con){}

        /// <summary>
        /// 保存配置
        /// </summary>
        public void SaveConfig()
        {
            SaveStorageConfig();
        }
        /// <summary>
        /// 保存配置
        /// </summary>
        protected virtual void SaveStorageConfig() { }

        /// <summary>
        /// 读取配置
        /// </summary>
        public  void LoadConfig()
        {
            LoadStorageConfig();
        }
        /// <summary>
        /// 读取配置
        /// </summary>
        protected virtual void LoadStorageConfig(){}

        /// <summary>
        /// 保存基本信息
        /// </summary>
        /// <param name="novelinfo"></param>
        public void SaveNovelInfo(NovelInfo novelinfo)
        {
            SaveTheNovelInfo(novelinfo);
        }

        /// <summary>
        /// 保存基本信息
        /// </summary>
        protected virtual void SaveTheNovelInfo(NovelInfo novelinfo){}

        /// <summary>
        /// 保存章节
        /// </summary>
        /// <param name="chapter"></param>
        public void SaveChapter(Chapter chapter)
        {
            SaveTheChapter(chapter);
        }
        /// <summary>
        /// 保存章节
        /// </summary>
        /// <param name="chapter"></param>
        protected virtual void SaveTheChapter(Chapter chapter){}
    }
}
