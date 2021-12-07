using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    [Serializable]
    public class BlueprintCreature 
    {
        public float xpos, ypos, zpos;
        public BlueprintCreature() { }
        public BlueprintCreature(float xpos, float ypos, float zpos)
        {
            this.xpos = xpos;
            this.ypos = ypos;
            this.zpos = zpos;
        }
    }
}
