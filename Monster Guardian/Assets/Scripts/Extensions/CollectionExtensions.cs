using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public static class CollectionExtensions
    {
        public static string ToJson<T>(this ICollection<T> collection)
        {
            return JsonUtility.ToJson(collection);
        }

        public static string ToJson<T>(this ICollection<T> collection, bool prettyPrint)
        {
            return JsonUtility.ToJson(collection, prettyPrint);
        }
    }
}