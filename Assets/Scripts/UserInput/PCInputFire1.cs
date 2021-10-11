using System;
using UnityEngine;

namespace Test2DGame
{
    internal sealed class PCInputFire1 : IUserInputProxy <bool>
    {
        public event Action<bool> AxisOnChange = delegate(bool f) {  };
        
        public void GetAxis()
        {
            AxisOnChange.Invoke(Input.GetKeyDown(KeyCode.Mouse0));
        }
    }
}