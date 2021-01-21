using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.Extensions
{
    public static class IDictionaryExtensions
    {
        public static Value GetOrDefault<Key, Value>(this IDictionary<Key, Value> dict, Key key, Value defaultValue)
        {
            if (dict.ContainsKey(key))
                return dict[key];
            else
                return defaultValue;
        }
    }
}
