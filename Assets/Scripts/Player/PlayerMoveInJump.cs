using UnityEngine;

namespace Test2DGame
{
    internal class PlayerMoveInJump : State
    {
        public override void Handle(PlayerState playerState, SpriteAnimator spriteAnimator, SpriteRenderer spriteRenderer, 
            PlayerContactsController playerContacts, float valueHorizontal, bool doJump, Rigidbody2D playerRb, 
            IUnit playerData, float fixedDeltaTime)
        {
            if (!(valueHorizontal > 0 && !playerContacts.HasRightContacts ||
                  valueHorizontal < 0 && !playerContacts.HasLeftContacts))
            {
                if (!doJump && playerContacts.IsGrounded)
                {
                    playerState.State = new PlayerIdle();
                }
                else
                {
                    playerState.State = new PlayerJumping();
                }
            }
            else if (!doJump && playerContacts.IsGrounded)
            {
                playerState.State = new PlayerMoveHorizontal();
            }
            else
            {
                spriteAnimator.StartAnimation(spriteRenderer, Track.Jump, true, playerData.AnimationSpeed);
                
                var isLeftMove = valueHorizontal < 0;
                spriteRenderer.flipX = isLeftMove;
                
                var newVelocity = fixedDeltaTime * playerData.MoveSpeed * (isLeftMove ? -1 : 1);
                
                playerRb.velocity = playerRb.velocity.Change(x: newVelocity);
                
                if (playerContacts.IsGrounded && playerRb.velocity.y < 3f)
                {
                    playerRb.AddForce(Vector2.up * playerData.JumpStartSpeed);
                }
                
            }
        }
    }
}
