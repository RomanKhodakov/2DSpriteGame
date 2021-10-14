using System;
using UnityEngine;

namespace Test2DGame
{
    internal sealed class PCInputFireFirst : IUserInputProxy <bool>
    {
        public event Action<bool> AxisOnChange = delegate(bool f) {  };
        
        public void GetAxis()
        {
            AxisOnChange.Invoke(Input.GetKeyDown(KeyCode.Mouse0));
        }
    }
}