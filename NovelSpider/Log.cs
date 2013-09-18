using System;
using System.Collections.Generic;
using System.Text;

namespace NovelSpider
{
    public static class Log
    {
        /// <summary>
        /// 输出
        /// </summary>
        /// <param name="msg"></param>
        public static void PrintLog(string msg)
        {
            bool scroll = false;
            if (Main.MsgBox.TopIndex == Main.MsgBox.Items.Count - (int)(Main.MsgBox.Height / Main.MsgBox.ItemHeight))
                scroll = true;
            Main.MsgBox.Items.Add(msg);
            if (scroll)
                Main.MsgBox.TopIndex = Main.MsgBox.Items.Count - (int)(Main.MsgBox.Height / Main.MsgBox.ItemHeight);
        }
    }
}
