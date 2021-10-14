using UnityEngine;

namespace Test2DGame
{
    internal sealed class PlayerMoveController : IExecute, ICleanup
    {
        private float _horizontal;
        private bool _doJump;
        private const float PlayerSpeed = 0.5f;
        private readonly IUserInputProxy<float> _horizontalInputProxy;
        private readonly IUserInputProxy<float> _verticalInputProxy;
        private readonly SpriteAnimator _spriteAnimator;
        private readonly SpriteRenderer _playerSpriteRenderer;
        private readonly PlayerState _playerState;

        public PlayerMoveController(
            (IUserInputProxy<float> inputHorizontal, IUserInputProxy<float> inputVertical, IUserInputProxy<bool>
                inputFire1) input, SpriteAnimator spriteAnimator, PlayerInitialization playerInitialization)
        {
            _horizontalInputProxy = input.inputHorizontal;
            _verticalInputProxy = input.inputVertical;
            _spriteAnimator = spriteAnimator;
            _playerSpriteRenderer = playerInitialization.GetPlayerSpriteRenderer();
            _playerState = playerInitialization.GetPlayerState();
            _horizontalInputProxy.AxisOnChange += HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange += VerticalOnAxisOnChange;
        }

        private void VerticalOnAxisOnChange(float value)
        {
            _doJump = value > 0;
        }

        private void HorizontalOnAxisOnChange(float value)
        {
            _horizontal = value;
        }

        public void Execute(float deltaTime)
        {
            _playerState.Request(_spriteAnimator, _playerSpriteRenderer, _horizontal, _doJump, PlayerSpeed, deltaTime);
        }

        public void Cleanup()
        {
            _horizontalInputProxy.AxisOnChange -= HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange -= VerticalOnAxisOnChange;
        }
    }
}