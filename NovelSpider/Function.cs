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
        /// 获取指定动态库ICollector实例
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static ICollector GetCollectorPluginInterface(string filepath)
        {
            if (!File.Exists(filepath))
                return null;

            Type type = null;
            ICollector ic = null;
            string fullname = string.Empty;

            try
            {
                Assembly ass = Assembly.LoadFile(filepath);
                Type[] tps = ass.GetTypes();


                foreach (Type t in tps)
                {
                    if (t.IsSubclassOf(typeof(Collector)))
                    {
                        fullname = t.FullName;
                        type = t;
                        break;
                    }
                }

                if (!string.IsNullOrEmpty(fullname))
                {
                    ic = ass.CreateInstance(fullname) as ICollector;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ic;
        }


        /// <summary>
        /// 获取指定动态库IStorager实例
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static IStorager GetStoragerPluginInterface(string filepath)
        {
            if (!File.Exists(filepath))
                return null;

            Type type = null;
            IStorager ist = null;
            string fullname = string.Empty;

            try
            {
                Assembly ass = Assembly.LoadFile(filepath);
                Type[] tps = ass.GetTypes();


                foreach (Type t in tps)
                {
                    if (t.IsSubclassOf(typeof(Storager)))
                    {
                        fullname = t.FullName;
                        type = t;
                        break;
                    }
                }

                if (!string.IsNullOrEmpty(fullname))
                {
                    ist = ass.CreateInstance(fullname) as Storager;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ist;
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
                Collector clo = null;


                foreach (Type t in tps)
                {
                    if (t.IsSubclassOf(typeof(Collector)))
                    {
                        fullname = t.FullName;
                        type = t;
                        break;
                    }
                }

                if (!string.IsNullOrEmpty(fullname))
                    clo = ass.CreateInstance(fullname) as Collector;
                if (clo != null)
                    res = clo.SiteName;
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
                Collector clo = null;


                foreach (Type t in tps)
                {
                    if (t.IsSubclassOf(typeof(Collector)))
                    {
                        fullname = t.FullName;
                        type = t;
                        break;
                    }
                }

                if (!string.IsNullOrEmpty(fullname))
                    clo = ass.CreateInstance(fullname) as Collector;
                if (clo != null)
                    res = clo.TargetSite;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }

        /// <summary>
        /// 获取指定动态库的站点名称
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static string GetTargetMethodName(string filepath)
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
                Storager sto = null;


                foreach (Type t in tps)
                {
                    if (t.IsSubclassOf(typeof(Storager)))
                    {
                        fullname = t.FullName;
                        type = t;
                        break;
                    }
                }

                if (!string.IsNullOrEmpty(fullname))
                    sto = ass.CreateInstance(fullname) as Storager;
                if (sto != null)
                    res = sto.MethodName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }
    }

}
