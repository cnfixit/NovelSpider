using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace NovelSpider
{
    /// <summary>
    /// 存储接口
    /// </summary>
    public interface IStorager
    {
        /// <summary>
        /// 初始化界面
        /// </summary>
        void InitUI(Control con);
        /// <summary>
        /// 保存配置
        /// </summary>
        void SaveConfig();
        /// <summary>
        /// 读取配置
        /// </summary>
        void LoadConfig();
        /// <summary>
        /// 保存基本信息
        /// </summary>
        /// <param name="novelinfo"></param>
        void SaveNovelInfo(NovelInfo novelinfo);
        /// <summary>
        /// 保存章节
        /// </summary>
        /// <param name="chapter"></param>
        void SaveChapter(Chapter chapter);
    }
}
