using System;
using System.Collections.Generic;
using UnityEngine;

namespace Test2DGame
{
    [Serializable]
    internal class SpritesSequence
    {
        public Track Track;
        public List<Sprite> Sprites = new List<Sprite>();
    }
}