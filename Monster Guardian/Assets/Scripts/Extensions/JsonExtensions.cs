using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Most of this information comes from https://stackoverflow.com/questions/36239705/serialize-and-deserialize-json-and-json-array-in-unity
    /// </summary>
    public static class JsonExtensions
    {
        /// <summary>
        /// Fix json arrays by adding an items list
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static string FixJson(this string json)
        {
            json = "{\"Items\":" + json + "}";
            return json;
        }

        public static T[] FromJson<T>(this string json)
        {
            BlueprintWrapper<T> wrapper = JsonUtility.FromJson<BlueprintWrapper<T>>(json);
            return wrapper.Items;
        }

        public static string ToJson<T>(this List<T> list)
        {
            BlueprintWrapper<T> wrapper = new BlueprintWrapper<T>();
            wrapper.Items = list.ToArray();
            return JsonUtility.ToJson(wrapper);
        }

        public static string ToJson<T>(this T[] array)
        {
            BlueprintWrapper<T> wrapper = new BlueprintWrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper);
        }

        public static string ToJson<T>(this List<T> list, bool prettyPrint)
        {
            BlueprintWrapper<T> wrapper = new BlueprintWrapper<T>();
            wrapper.Items = list.ToArray();
            return JsonUtility.ToJson(wrapper, prettyPrint);
        }

        public static string ToJson<T>(this T[] array, bool prettyPrint)
        {
            BlueprintWrapper<T> wrapper = new BlueprintWrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper, prettyPrint);
        }
    }
}