using UnityEngine;

namespace Test2DGame
{
    public interface IUnit
    {
        SpriteRenderer SpriteRenderer { get; }
        string Name { get; }
        float Speed { get; }
        float Mass { get; }
    }
}