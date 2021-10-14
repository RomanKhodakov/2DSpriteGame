using UnityEngine;

namespace Test2DGame
{
    public interface IUnit
    {
        Sprite Sprite { get; }
        string Name { get; }
        float Speed { get; }
        float Mass { get; }
        float ColliderRadius { get; }
    }
}