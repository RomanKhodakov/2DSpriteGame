using System;

namespace Test2DGame
{
    public interface IUserInputProxy <T>
    {
        event Action<T> AxisOnChange;
        void GetAxis();
    }
}