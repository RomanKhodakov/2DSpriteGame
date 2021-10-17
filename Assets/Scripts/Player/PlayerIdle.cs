using UnityEngine;

namespace Test2DGame
{
    internal class PlayerIdle : State
    {
        public override void Handle(PlayerState playerState, SpriteAnimator spriteAnimator, SpriteRenderer spriteRenderer, 
            PlayerContactsController playerContacts, float valueHorizontal, bool doJump, Rigidbody2D playerRb, 
            IUnit playerData, float fixedDeltaTime)
        {
            if (valueHorizontal > 0 && !playerContacts.HasRightContacts || 
                valueHorizontal < 0 && !playerContacts.HasLeftContacts)
            {
                if (!doJump && playerContacts.IsGrounded)
                {
                    playerState.State = new PlayerMoveHorizontal();
                }
                else
                {                
                    playerState.State = new PlayerMoveInJump();
                }
            }
            else if (doJump)
            {
                playerState.State = new PlayerJumping();
            }
            else
            {
                spriteAnimator.StartAnimation(spriteRenderer, Track.Idle, true, playerData.AnimationSpeed/4);
            }
        }
    }
}