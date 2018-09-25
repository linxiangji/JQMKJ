using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnuDevInfoOnUserCommon.HelpTools
{
    [Serializable]
    public class ClsDictionaryHelper
    {
        public static void AddKeyValue<TKey, TVlaue>(Dictionary<TKey,TVlaue> currDictionary, TKey key, TVlaue value)
        {
            currDictionary.Add(key,value);
        }

        public static void RemoveKey<TKey, TVlaue>(Dictionary<TKey, TVlaue> currDictionary, TKey delKey)
        {
            currDictionary.Remove(delKey);
        }

        public static bool IsContainKey<TKey, TVlaue>(Dictionary<TKey, TVlaue> currDictionary, TKey findKey)
        {
            return currDictionary.ContainsKey(findKey);
        }
       
        public static bool KeyValuePair<TKey, TVlaue>(Dictionary<TKey, TVlaue> currDictionary, TKey findKey)
        {
            bool isContainKeyFlag = false;
            foreach (KeyValuePair<TKey, TVlaue> currOptKey in currDictionary)
            {
                if (currDictionary.ContainsKey(findKey))
                {
                    isContainKeyFlag = true;
                    break;
                }
            }
            return isContainKeyFlag;
        }
    }
}
