using System;
using UnityEngine;

namespace Test2DGame
{
    internal sealed class PCInputHorizontal : IUserInputProxy <float> 
    {
        public event Action<float> AxisOnChange = delegate(float f) {  };
        
        public void GetAxis()
        {
            AxisOnChange.Invoke(Input.GetAxis(AxisManager.HORIZONTAL));
        }
    }
}