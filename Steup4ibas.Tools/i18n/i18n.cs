using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Steup4ibas.Tools.i18n
{
    public class i18n
    {
        private i18n()
        {
        }

        //private volatile static ILanguageItemManager instance;

        //public static ILanguageItemManager getInstance() {
        //    if (instance == null) {
        //        lock (true) {
        //            if (instance == null) {
        //                instance = new LanguageItemManager();
        //                instance.readResources();
        //            }
        //        }
        //    }
        //    return instance;
        //}

        /// <summary>
        /// 获取key所对应的值
        /// </summary>
        /// <param name="key">需要翻译的文本</param>
        /// <param name="args">有效值</param>
        /// <returns>返回key所对应的值</returns>
        public static string prop(string key, object args)
        {
            //return getInstance().getContent(key, args);
            return key;
        }
    }
}
