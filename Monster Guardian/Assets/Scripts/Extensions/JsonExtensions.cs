using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// JSON conversions for strings and class objects.
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

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T[] FromJson<T>(this string json)
        {
            BlueprintWrapper<T> wrapper = JsonUtility.FromJson<BlueprintWrapper<T>>(json);
            return wrapper.Items;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string ToJson<T>(this List<T> list)
        {
            BlueprintWrapper<T> wrapper = new BlueprintWrapper<T>();
            wrapper.Items = list.ToArray();
            return JsonUtility.ToJson(wrapper);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public static string ToJson<T>(this T[] array)
        {
            BlueprintWrapper<T> wrapper = new BlueprintWrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="prettyPrint"></param>
        /// <returns></returns>
        public static string ToJson<T>(this List<T> list, bool prettyPrint)
        {
            BlueprintWrapper<T> wrapper = new BlueprintWrapper<T>();
            wrapper.Items = list.ToArray();
            return JsonUtility.ToJson(wrapper, prettyPrint);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="prettyPrint"></param>
        /// <returns></returns>
        public static string ToJson<T>(this T[] array, bool prettyPrint)
        {
            BlueprintWrapper<T> wrapper = new BlueprintWrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper, prettyPrint);
        }
    }
}