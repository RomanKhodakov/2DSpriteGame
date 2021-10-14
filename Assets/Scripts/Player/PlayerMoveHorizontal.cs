using UnityEngine;

namespace Test2DGame
{
    internal class PlayerMoveHorizontal : State
    {
        public override void Handle(PlayerState playerState, SpriteAnimator spriteAnimator, SpriteRenderer spriteRenderer, 
            float valueHorizontal, bool doJump, Transform playerTransform, float playerSpeed, float deltaTime)
        {
            if (valueHorizontal == 0)
            {
                if (!doJump)
                {
                    playerState.State = new PlayerIdle();
                }
                else
                {
                    playerState.State = new PlayerJumping();
                }
            }
            else if (doJump)
            {
                playerState.State = new PlayerMoveInJump(VerticalVelocity);
            }
            else
            {
                spriteAnimator.StartAnimation(spriteRenderer, Track.Walk, true, AnimationSpeed);
                playerTransform.position += Vector3.right * (deltaTime * playerSpeed * (valueHorizontal < 0 ? -1 : 1));
                spriteRenderer.flipX = valueHorizontal < 0;
            }
        }
    }
}