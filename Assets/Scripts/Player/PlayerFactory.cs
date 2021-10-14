using UnityEngine;

namespace Test2DGame
{
    internal sealed class PlayerFactory
    {
        private readonly IUnit _playerData;

        public PlayerFactory(IUnit playerData)
        {
            _playerData = playerData;
        }

        public PlayerView CreatePlayer()
        {
            return new GameObject(_playerData.Name).AddCircleCollider2D(_playerData.ColliderRadius).
                AddRigidbody2D(_playerData.Mass).AddSprite(_playerData.Sprite).AddComponent<PlayerView>();
        }
    }
}