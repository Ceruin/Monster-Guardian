using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public static class GameObjectExtensions
    {
        public static bool HasValue(this GameObject gameObject)
        {
            return gameObject != null;
        }
    }
}
