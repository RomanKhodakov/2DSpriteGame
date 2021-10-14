using System;
using UnityEngine;

namespace Test2DGame
{
    internal class PlayerJumping : State
    {
        private bool _isInJump = true;
        public override void Handle(PlayerState playerState, SpriteAnimator spriteAnimator, SpriteRenderer spriteRenderer,
            float valueHorizontal, bool doJump, Transform playerTransform, float playerSpeed, float deltaTime)
        {
            if (!doJump && !_isInJump)
            {
                if (valueHorizontal == 0)
                {
                    playerState.State = new PlayerIdle();
                }
                else
                {
                    playerState.State = new PlayerMoveHorizontal();
                }
            }
            else if (valueHorizontal != 0)
            {
                playerState.State = new PlayerMoveInJump(VerticalVelocity);
            }
            else
            {
                spriteAnimator.StartAnimation(spriteRenderer, Track.Jump, true, AnimationSpeed);
                
                playerTransform.position += Vector3.up * (deltaTime * VerticalVelocity);
                VerticalVelocity += Gravity * deltaTime;
                if (playerTransform.position.y <= StartVerticalCoordinate)
                {
                    _isInJump = false;
                    VerticalVelocity = JumpStartSpeed;
                }
            }
        }
    }
}