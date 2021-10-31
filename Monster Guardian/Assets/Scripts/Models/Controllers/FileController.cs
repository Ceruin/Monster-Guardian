using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// todo: save world into file
public static class FileController
{
    public static void Save(string file, string json)
    {
        var assemblyPath = Application.persistentDataPath;
        File.WriteAllText(Path.Combine(assemblyPath, file), json);
    }
}