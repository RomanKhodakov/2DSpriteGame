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
            var res = new GameObject(_playerData.Name).AddSprite(_playerData.Sprite);
            res.GetOrAddComponent<CapsuleCollider2D>().size = new Vector2(_playerData.ColliderSizeX, _playerData.ColliderSizeY);
            return res.AddComponent<PlayerView>();
        }
    }
}