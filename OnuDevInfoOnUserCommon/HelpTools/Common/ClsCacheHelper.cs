using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace OnuDevInfoOnUserCommon.HelpTools
{
    public class ClsCacheHelper
    {
        /// <summary>
        /// 增加一个缓存对象
        /// </summary>
        /// <param name="strKey">键值名称</param>
        /// <param name="valueObj">被缓存对象</param>
        /// <param name="durationMin">缓存失效时间（默认为5分钟）</param>
        /// <param name="cachePriority">保留优先级(枚举数值)</param>
        /// <returns>缓存写入是否成功true 、false</returns>
        public static bool InsertCach(string strKey, object valueObj, int durationMin,
            CacheItemPriority cachePriority = CacheItemPriority.Default)
        {
            TimeSpan ts;
            if (!string.IsNullOrWhiteSpace(strKey) && valueObj != null)
            {
                //onRemove是委托执行的函数，具体方法看下面的onRemove(...)
                CacheItemRemovedCallback callBack = new CacheItemRemovedCallback(onRemove);
                ts = durationMin == 0 ? new TimeSpan(0, 5, 0) : new TimeSpan(0, durationMin, 0);
                //HttpContext.Current.Cache.Insert(
                HttpRuntime.Cache.Insert(
                    strKey,
                    valueObj,
                    null,
                    DateTime.Now.Add(ts),
                    Cache.NoSlidingExpiration,
                    cachePriority,
                    callBack
                );
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 判断缓存对象是否存在
        /// </summary>
        /// <param name="strKey">缓存键值名称</param>
        /// <returns>是否存在true 、false</returns>
        public static bool IsExist(string strKey)
        {
            //return HttpContext.Current.Cache[strKey] != null;
            return HttpRuntime.Cache.Get(strKey) != null;
        }

        /// <summary>
        /// 读取缓存对象
        /// </summary>
        /// <param name="strKey">缓存键值名称</param>
        /// <returns>缓存对象，objec类型</returns>
        public static object GetCache(string strKey)
        {
            //if (HttpContext.Current.Cache[strKey] != null)
            if (IsExist(strKey))
            {
                object obj = HttpRuntime.Cache.Get(strKey);
                return obj ?? null;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 移除缓存对象
        /// </summary>
        /// <param name="strKey">缓存键值名称</param>
        public static void Remove(string strKey)
        {
            //if (HttpContext.Current.Cache[strKey] != null)
            if (IsExist(strKey))
            {
                HttpRuntime.Cache.Remove(strKey);
            }
        }

        /// <summary>
        /// 清除所有缓存
        /// </summary>
        public static void Clear()
        {
            IDictionaryEnumerator enu = HttpRuntime.Cache.GetEnumerator();
            while (enu.MoveNext())
            {
                Remove(enu.Key.ToString());
            }
        }

        public static CacheItemRemovedReason reason;
        /// <summary>
        /// 此方法在值失效之前调用，可以用于在失效之前更新数据库，或从数据库重新获取数据
        /// </summary>
        /// <param name="strKey"></param>
        /// <param name="obj"></param>
        /// <param name="reason"></param>
        private static void onRemove(string strKey, object obj, CacheItemRemovedReason r)
        {
            reason = r;
        }
    }
}
