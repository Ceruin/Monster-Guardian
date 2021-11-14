using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Extensions
{
    public static class FileExtensions
    {
        public static FileInfo GetAppFile(string file)
        {
            var assemblyPath = Application.persistentDataPath;
            return new FileInfo(Path.Combine(assemblyPath, file));
    }

        public static void SaveJson(this string file, string json)
        {
            File.WriteAllText(file, json);
        }

        public static T LoadJson<T>(this string file)
        {
            return File.ReadAllText(file).FromJson<T>();
        }
    }
}
