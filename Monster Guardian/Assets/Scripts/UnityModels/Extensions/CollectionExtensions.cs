using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public static class  CollectionExtensions
{
    public static string ToJson<T>(ICollection<T> collection)
    {
        return JsonUtility.ToJson(collection);
    }

    public static string ToJson<T>(ICollection<T> collection, bool prettyPrint)
    {
        return JsonUtility.ToJson(collection, prettyPrint);
    }
}
