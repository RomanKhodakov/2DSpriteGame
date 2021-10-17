using System.Collections.Generic;
using UnityEngine;

namespace Test2DGame
{
    internal sealed class InteractiveObjectsFactory
    {

        public InteractiveObjectsFactory()
        {
            
        }

        public CheckPointView GetCheckPoint()
        {
            var res = Resources.Load<CheckPointView>($"CheckPoint/CheckPoint");
            return res;
        }
    }
}