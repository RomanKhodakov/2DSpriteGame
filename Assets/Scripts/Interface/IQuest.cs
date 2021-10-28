using System;

namespace Test2DGame
{
    internal interface IQuest
    {
        event Action<IQuest> Completed;
        bool IsCompleted { get; }
        void Reset();
    }
}
