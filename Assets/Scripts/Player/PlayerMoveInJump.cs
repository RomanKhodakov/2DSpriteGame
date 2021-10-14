using UnityEngine;

namespace Test2DGame
{
    internal class PlayerMoveInJump : State
    {
        private bool _isInJump = true;

        public PlayerMoveInJump(float currentVerticalVelocity)
        {
            VerticalVelocity = currentVerticalVelocity;
        }
        public override void Handle(PlayerState playerState, SpriteAnimator spriteAnimator, SpriteRenderer spriteRenderer, 
            float valueHorizontal, bool doJump, Transform playerTransform, float playerSpeed, float deltaTime)
        {
            if (valueHorizontal == 0 && !_isInJump)
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
            else if (!doJump && !_isInJump)
            {
                playerState.State = new PlayerMoveHorizontal();
            }
            else
            {
                spriteAnimator.StartAnimation(spriteRenderer, Track.Jump, true, AnimationSpeed);
                
                playerTransform.position += Vector3.up * (deltaTime * VerticalVelocity);
                
                VerticalVelocity += Gravity * deltaTime;
                
                if (valueHorizontal != 0)
                {
                    playerTransform.position += Vector3.right * (deltaTime * playerSpeed * (valueHorizontal < 0 ? -1 : 1));
                    spriteRenderer.flipX = valueHorizontal < 0;
                }
                
                if (playerTransform.position.y <= StartVerticalCoordinate)
                {
                    _isInJump = false;
                    VerticalVelocity = JumpStartSpeed;
                }
            }
        }
    }
}
