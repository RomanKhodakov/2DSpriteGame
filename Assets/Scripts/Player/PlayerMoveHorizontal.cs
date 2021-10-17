using UnityEngine;

namespace Test2DGame
{
    internal class PlayerMoveHorizontal : State
    {
        public override void Handle(PlayerState playerState, SpriteAnimator spriteAnimator, SpriteRenderer spriteRenderer, 
            PlayerContactsController playerContacts, float valueHorizontal, bool doJump, Rigidbody2D playerRb, 
            IUnit playerData, float fixedDeltaTime)
        {
            if (!(valueHorizontal > 0 && !playerContacts.HasRightContacts || 
                valueHorizontal < 0 && !playerContacts.HasLeftContacts))
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
                playerState.State = new PlayerMoveInJump();
            }
            else
            {
                spriteAnimator.StartAnimation(spriteRenderer, Track.Walk, true, playerData.AnimationSpeed);

                var isLeftMove = valueHorizontal < 0;
                spriteRenderer.flipX = isLeftMove;
                
                var newVelocity = fixedDeltaTime * playerData.MoveSpeed * (isLeftMove ? -1 : 1);
                
                playerRb.velocity = playerRb.velocity.Change(x: newVelocity);
            }
        }
    }
}