using UnityEngine;

namespace Test2DGame
{
    internal sealed class PlayerState
    {
        private State _state;
        private readonly Rigidbody2D _playerRb;


        public PlayerState(State state, Rigidbody2D playerRb)
        {
            State = state;
            _playerRb = playerRb;
        }

        public State State
        {
            get => _state;
            set => _state = value;
        }

        public void Request(SpriteAnimator spriteAnimator, SpriteRenderer spriteRenderer, 
            PlayerContactsController playerContacts, float valueHorizontal,
            bool doJump, IUnit playerData, float fixedDeltaTime)
        {
            _state.Handle(this, spriteAnimator, spriteRenderer, playerContacts, 
                valueHorizontal, doJump, _playerRb, playerData, fixedDeltaTime);
        }
    }
}