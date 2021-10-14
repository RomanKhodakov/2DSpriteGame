using UnityEngine;

namespace Test2DGame
{
    internal abstract class State
    {
        protected const float AnimationSpeed = 10f;
        protected const float Gravity = -9.8f;
        protected const float JumpStartSpeed = 3f;
        protected float VerticalVelocity = JumpStartSpeed;
        protected float StartVerticalCoordinate = 0.05f;

        public abstract void Handle(PlayerState playerState, SpriteAnimator spriteAnimator, SpriteRenderer spriteRenderer, 
            float valueHorizontal, bool doJump, Transform playerTransform, float playerSpeed, float deltaTime);
    }
}