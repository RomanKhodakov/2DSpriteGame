using UnityEngine;

namespace Test2DGame
{
    internal sealed class PlayerInitialization : IInitialization
    {
        private const int PlayerSortOrder = 3;
        private readonly PlayerView _playerView;
        private readonly SpriteRenderer _spriteRenderer;
        private readonly PlayerState _playerState;
        private readonly Rigidbody2D _playerRb;
        private readonly Transform _playerTransform;
        private readonly Collider2D _playerCollider;

        public PlayerInitialization(PlayerFactory playerFactory)
        {
            _playerView = playerFactory.CreatePlayer();
            _spriteRenderer = _playerView.SpriteRenderer;
            _playerTransform = _playerView.gameObject.transform;
            _playerRb = _playerView.gameObject.GetOrAddComponent<Rigidbody2D>();
            _playerCollider = _playerView.gameObject.GetOrAddComponent<Collider2D>();
            _playerState = new PlayerState(new PlayerIdle(), _playerRb);
        }
        
        public void Initialization()
        {
            _spriteRenderer.sortingOrder = PlayerSortOrder;
            _playerRb.freezeRotation = true;
        }

        public PlayerView GetPlayerView() => _playerView;
        public SpriteRenderer GetPlayerSpriteRenderer() => _spriteRenderer;
        
        public Transform GetPlayerTransform() => _playerTransform;

        public Rigidbody2D GetPlayerRigidbody() => _playerRb;
        public Collider2D GetPlayerCollider() => _playerCollider;
        
        public PlayerState GetPlayerState() => _playerState;
    }
}