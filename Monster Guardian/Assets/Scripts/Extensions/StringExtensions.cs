using UnityEngine;

public static class StringExtensions
{
    public static T FromJson<T>(this string json)
    {
        return JsonUtility.FromJson<T>(json);
    }

    public static string ToJson(this object obj)
    {
        return JsonUtility.ToJson(obj, true);
    }
}