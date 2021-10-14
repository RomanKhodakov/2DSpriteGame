using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test2DGame
{
    internal class PlayerAnimation
    {
        public Track Track;
        public List<Sprite> Sprites;
        public bool Loop = false;
        public float Speed;
        public float Counter;
        public bool Sleeps;

        public void Update()
        {
            if (Sleeps) return;
            Counter += Time.deltaTime * Speed;
            if (Loop)
            {
                while (Counter > Sprites.Count)
                {
                    Counter -= Sprites.Count;
                }
            }
            else if (Counter > Sprites.Count)
            {
                Counter = Sprites.Count - 1;
                Sleeps = true;
            }
        }
    }
}
