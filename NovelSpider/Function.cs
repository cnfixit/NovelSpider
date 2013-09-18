using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;

namespace NovelSpider
{
    public static class Function
    {



        /// <summary>
        /// 获取指定动态库IProcedure实例
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static IProcedure GetPluginInterface(string filepath)
        {
            if (!File.Exists(filepath))
                return null;

            Type type = null;
            IProcedure ip = null;
            string fullname = string.Empty;

            try
            {
                Assembly ass = Assembly.LoadFile(filepath);
                Type[] tps = ass.GetTypes();


                foreach (Type t in tps)
                {
                    if (t.IsSubclassOf(typeof(Procedure)))
                    {
                        fullname = t.FullName;
                        type = t;
                        break;
                    }
                }

                if (!string.IsNullOrEmpty(fullname))
                {
                    ip = ass.CreateInstance(fullname) as IProcedure;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return ip;
        }

        /// <summary>
        /// 获取指定动态库的站点名称
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static  string GetTargetSiteName(string filepath)
        {
            if (!File.Exists(filepath))
                return null;

            string res = string.Empty;
            try
            {
                Assembly ass = Assembly.LoadFile(filepath);

                Type[] tps = ass.GetTypes();
                Type type = null;
                string fullname = string.Empty;
                Procedure pro = null;


                foreach (Type t in tps)
                {
                    if (t.IsSubclassOf(typeof(Procedure)))
                    {
                        fullname = t.FullName;
                        type = t;
                        break;
                    }
                }

                if (!string.IsNullOrEmpty(fullname))
                    pro = ass.CreateInstance(fullname) as Procedure;
                if (pro != null)
                    res = pro.SiteName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }


        /// <summary>
        /// 获取指定动态库的目标地址列表信息
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static  List<Uri> GetTargetSiteList(string filepath)
        {
            if (!File.Exists(filepath))
                return null;

            List<Uri> res = null;
            try
            {
                Assembly ass = Assembly.LoadFile(filepath);

                Type[] tps = ass.GetTypes();
                Type type = null;
                string fullname = string.Empty;
                Procedure pro = null;


                foreach (Type t in tps)
                {
                    if (t.IsSubclassOf(typeof(Procedure)))
                    {
                        fullname = t.FullName;
                        type = t;
                        break;
                    }
                }

                if (!string.IsNullOrEmpty(fullname))
                    pro = ass.CreateInstance(fullname) as Procedure;
                if (pro != null)
                    res = pro.TargetSite;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }
    }

}
