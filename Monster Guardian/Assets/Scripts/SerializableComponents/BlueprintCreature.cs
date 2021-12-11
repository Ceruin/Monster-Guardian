using System;

namespace Assets.Scripts
{
    /// <summary>
    /// This is a JSON conversion class for the Creature class to store it’s serializable data into a JSON file.
    /// </summary>
    [Serializable]
    public class BlueprintCreature
    {
        public string tag;
        public float xpos;
        public float ypos;
        public float zpos;

        public BlueprintCreature()
        { }

        public BlueprintCreature(float _xpos, float _ypos, float _zpos, string _tag)
        {
            this.xpos = _xpos;
            this.ypos = _ypos;
            this.zpos = _zpos;
            this.tag = _tag;
        }
    }
}