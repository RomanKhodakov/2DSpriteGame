using System.Collections.Generic;
using UnityEngine;

namespace Test2DGame
{
    internal sealed class GunFactory
    {

        public GunFactory()
        {
            
        }

        public GameObject GetGun()
        {
            var res = Resources.Load<GameObject>($"Gun/Gun");
            return res;
        }
    }
}