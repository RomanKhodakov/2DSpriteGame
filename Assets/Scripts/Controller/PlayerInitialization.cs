using UnityEngine;

namespace Test2DGame
{
    internal sealed class PlayerInitialization : IInitialization
    {
        private const int PlayerSortOrder = 3;
        private const float PlayerGravityScale = 0.05f;
        private readonly SpriteRenderer _spriteRenderer;
        private readonly PlayerState _playerState;
        private readonly Rigidbody2D _playerRb;
        private readonly Transform _playerTransform;

        public PlayerInitialization(PlayerFactory playerFactory)
        {
            var playerView = playerFactory.CreatePlayer();
            _spriteRenderer = playerView.SpriteRenderer;
            _playerTransform = playerView.gameObject.transform;
            _playerRb = playerView.gameObject.GetOrAddComponent<Rigidbody2D>();
            _playerState = new PlayerState(new PlayerIdle(), _playerTransform);
        }
        
        public void Initialization()
        {
            _spriteRenderer.sortingOrder = PlayerSortOrder;
            _playerRb.gravityScale = PlayerGravityScale;
            _playerRb.freezeRotation = true;
        }

        public SpriteRenderer GetPlayerSpriteRenderer() => _spriteRenderer;
        
        public Transform GetPlayerTransform() => _playerTransform;

        public Rigidbody2D GetPlayerRigidbody() => _playerRb;
        
        public PlayerState GetPlayerState() => _playerState;
    }
}