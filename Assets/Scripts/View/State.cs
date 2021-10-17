using UnityEngine;

namespace Test2DGame
{
    internal abstract class State
    {
        public abstract void Handle(PlayerState playerState, SpriteAnimator spriteAnimator, SpriteRenderer spriteRenderer, 
            PlayerContactsController playerContacts, float valueHorizontal, bool doJump, Rigidbody2D playerRb, 
            IUnit playerData, float fixedDeltaTime);
    }
}