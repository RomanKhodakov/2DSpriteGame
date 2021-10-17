using UnityEngine;

namespace Test2DGame
{
    internal sealed class PlayerMoveController : IFixedExecute, ICleanup
    {
        private float _horizontal;
        private bool _doJump;
        private const float PlayerSpeed = 30f;
        private readonly IUserInputProxy<float> _horizontalInputProxy;
        private readonly IUserInputProxy<float> _verticalInputProxy;
        private readonly SpriteAnimator _spriteAnimator;
        private readonly SpriteRenderer _playerSpriteRenderer;
        private readonly PlayerState _playerState;
        private readonly PlayerContactsController _playerContacts;
        private readonly IUnit _playerData;

        public PlayerMoveController(
            (IUserInputProxy<float> inputHorizontal, IUserInputProxy<float> inputVertical, IUserInputProxy<bool>
                inputFire1) input, SpriteAnimator spriteAnimator, PlayerInitialization playerInitialization, 
            PlayerContactsController playerContacts, IUnit playerData)
        {
            _playerData = playerData;
            _horizontalInputProxy = input.inputHorizontal;
            _verticalInputProxy = input.inputVertical;
            _spriteAnimator = spriteAnimator;
            _playerSpriteRenderer = playerInitialization.GetPlayerSpriteRenderer();
            _playerState = playerInitialization.GetPlayerState();
            _playerContacts = playerContacts;
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

        public void FixedExecute(float fixedDeltaTime)
        {
            _playerState.Request(_spriteAnimator, _playerSpriteRenderer, _playerContacts, _horizontal, _doJump, 
                _playerData, fixedDeltaTime);
        }

        public void Cleanup()
        {
            _horizontalInputProxy.AxisOnChange -= HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange -= VerticalOnAxisOnChange;
        }
    }
}