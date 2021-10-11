using UnityEngine;

namespace Test2DGame
{
    internal sealed class PlayerMoveController : IExecute, ICleanup
    {
        private float _horizontal;
        private float _vertical;
        private const float AnimationSpeed = 10f;
        private readonly IUserInputProxy <float>  _horizontalInputProxy;
        private readonly IUserInputProxy <float>  _verticalInputProxy;
        private readonly SpriteAnimator _spriteAnimator;
        private readonly SpriteRenderer _playerSpriteRenderer;

        public PlayerMoveController((IUserInputProxy<float> inputHorizontal, IUserInputProxy<float> inputVertical, IUserInputProxy<bool>
                inputFire1) input, SpriteAnimator spriteAnimator, SpriteRenderer playerSpriteRenderer)
        {
            _horizontalInputProxy = input.inputHorizontal;
            _verticalInputProxy = input.inputVertical;
            _spriteAnimator = spriteAnimator;
            _playerSpriteRenderer = playerSpriteRenderer;
            _horizontalInputProxy.AxisOnChange += HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange += VerticalOnAxisOnChange;
        }

        private void VerticalOnAxisOnChange(float value)
        {
            _vertical = value;
        }

        private void HorizontalOnAxisOnChange(float value)
        {
            _horizontal = value;
        }

        public void Execute(float deltaTime)
        {
            if (_horizontal != 0)
            {
                _spriteAnimator.StartAnimation(_playerSpriteRenderer, Track.Walk, true, AnimationSpeed);
            }
        }

        public void Cleanup()
        {
            _horizontalInputProxy.AxisOnChange -= HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange -= VerticalOnAxisOnChange;
        }
    }
}