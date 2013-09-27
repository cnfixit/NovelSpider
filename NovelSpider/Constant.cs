using System;
using System.Collections.Generic;
using System.Text;

namespace NovelSpider
{
    public static class Constant
    {
        /// <summary>
        /// 规则动态库目录
        /// </summary>
        public static string COLLECT_RULE_PATH = AppDomain.CurrentDomain.BaseDirectory + @"Collectors\";

        public static string STORAGE_RULE_PATH = AppDomain.CurrentDomain.BaseDirectory + @"Storagers\";
    }
}
