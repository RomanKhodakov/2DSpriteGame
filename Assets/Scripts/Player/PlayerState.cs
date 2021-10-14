using UnityEngine;

namespace Test2DGame
{
    internal sealed class PlayerState
    {
        private State _state;
        private readonly Transform _playerTransform;


        public PlayerState(State state, Transform playerTransform)
        {
            State = state;
            _playerTransform = playerTransform;
        }

        public State State
        {
            get => _state;
            set => _state = value;
        }

        public void Request(SpriteAnimator spriteAnimator, SpriteRenderer spriteRenderer, float valueHorizontal,
            bool doJump, float playerSpeed, float deltaTime)
        {
            _state.Handle(this, spriteAnimator, spriteRenderer, valueHorizontal, doJump,
                _playerTransform, playerSpeed, deltaTime);
        }
    }
}