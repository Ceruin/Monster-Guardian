using System;

namespace Assets.Scripts
{
    /// <summary>
    /// A blueprint wrapper class to convert object collections to a parasable entity in the Unity JSON framework.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class BlueprintWrapper<T>
    {
        public T[] Items;
    }
}