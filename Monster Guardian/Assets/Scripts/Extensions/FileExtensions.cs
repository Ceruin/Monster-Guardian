using System.IO;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Additional file extensions primarily JSON file work.
    /// </summary>
    public static class FileExtensions
    {
        /// <summary>
        /// Gets a static application path regardless of the users machine setup
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static FileInfo GetAppFile(this string file)
        {
            var assemblyPath = Application.persistentDataPath;
            return new FileInfo(Path.Combine(assemblyPath, file));
        }

        /// <summary>
        /// Load from a json filepath
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="file"></param>
        /// <returns></returns>
        public static T[] LoadJson<T>(this string file)
        {
            return File.ReadAllText(file).FromJson<T>();
        }

        /// <summary>
        /// Save json string to a file path
        /// </summary>
        /// <param name="file"></param>
        /// <param name="json"></param>
        public static void SaveJson(this string file, string json)
        {
            File.WriteAllText(file, json);
        }
    }
}