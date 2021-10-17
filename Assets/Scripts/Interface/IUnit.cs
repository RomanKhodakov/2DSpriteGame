using UnityEngine;

namespace Test2DGame
{
    public interface IUnit
    {
        Sprite Sprite { get; }
        string Name { get; }
        float Mass { get; }
        float ColliderSizeX { get; }
        float ColliderSizeY { get; }
        public float MoveSpeed { get; }
        public float AnimationSpeed { get; }
        public float JumpStartSpeed { get; }
    }
}