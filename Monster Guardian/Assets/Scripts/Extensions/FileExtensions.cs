using System.IO;
using UnityEngine;

public static class FileExtensions
{
    public static FileInfo GetAppFile(string file)
    {
        var assemblyPath = Application.persistentDataPath;
        return new FileInfo(Path.Combine(assemblyPath, file));
    }

    public static T LoadJson<T>(this string file)
    {
        return File.ReadAllText(file).FromJson<T>();
    }

    public static void SaveJson(this string file, string json)
    {
        File.WriteAllText(file, json);
    }
}