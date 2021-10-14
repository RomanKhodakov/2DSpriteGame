using UnityEngine;

namespace Test2DGame
{
    internal class PlayerIdle : State
    {
        public override void Handle(PlayerState playerState, SpriteAnimator spriteAnimator, SpriteRenderer spriteRenderer, 
            float valueHorizontal, bool doJump, Transform playerTransform, float playerSpeed, float deltaTime)
        {
            if (valueHorizontal != 0)
            {
                if (doJump)
                {
                    playerState.State = new PlayerMoveInJump(VerticalVelocity);
                }
                else
                {
                    playerState.State = new PlayerMoveHorizontal();
                }
            }
            else if (doJump)
            {
                playerState.State = new PlayerJumping();
            }
            else
            {
                spriteAnimator.StartAnimation(spriteRenderer, Track.Idle, true, AnimationSpeed/4);
            }
        }
    }
}