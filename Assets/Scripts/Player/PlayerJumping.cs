using System;
using UnityEngine;

namespace Test2DGame
{
    internal class PlayerJumping : State
    {
        public override void Handle(PlayerState playerState, SpriteAnimator spriteAnimator, SpriteRenderer spriteRenderer, 
            PlayerContactsController playerContacts, float valueHorizontal, bool doJump, Rigidbody2D playerRb, 
            IUnit playerData, float fixedDeltaTime)
        {
            if (!doJump && playerContacts.IsGrounded)
            {
                if (!(valueHorizontal > 0 && !playerContacts.HasRightContacts ||
                      valueHorizontal < 0 && !playerContacts.HasLeftContacts))
                {
                    playerState.State = new PlayerIdle();
                }
                else
                {
                    playerState.State = new PlayerMoveHorizontal();
                }
            }
            else if ((valueHorizontal > 0 && !playerContacts.HasRightContacts ||
                       valueHorizontal < 0 && !playerContacts.HasLeftContacts))
            {
                playerState.State = new PlayerMoveInJump();
            }
            else
            {
                spriteAnimator.StartAnimation(spriteRenderer, Track.Jump, true, playerData.AnimationSpeed);

                if (playerContacts.IsGrounded && playerRb.velocity.y < 3f)
                {
                    playerRb.AddForce(Vector2.up * playerData.JumpStartSpeed);
                }
            }
        }
    }
}