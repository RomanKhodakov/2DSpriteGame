using System.Collections.Generic;
using UnityEngine;

namespace Test2DGame
{
    internal sealed class PlayerTriggerController : IInitialization, ICleanup
    {
        private readonly PlayerView _playerView;
        private readonly Dictionary<int, Bullet> _bulletsWithID;
        private readonly ViewServices<Bullet> _bulletViewServices;
        private readonly EndGameUIController _endGameUIController;

        public PlayerTriggerController(PlayerInitialization player, IBulletFactory bulletFactory, EndGameUIController endGameUIController)
        {
            _playerView = player.GetPlayerView();
            _bulletsWithID = bulletFactory.GetBulletsWithID();
            _bulletViewServices = bulletFactory.GetBulletViewServices();
            _endGameUIController = endGameUIController;
        }

        public void Initialization()
        {
            _playerView.OnTriggerEnterChange += PlayerOnOnTriggerEnterChange;
        }

        private void PlayerOnOnTriggerEnterChange(int otherID)
        {
            if (_bulletsWithID.ContainsKey(otherID))
            {
                _bulletViewServices.Destroy(_bulletsWithID[otherID]);
                _playerView.IsDead = true;
                _endGameUIController.ShowEndGameUi();
            }
        }

        public void Cleanup()
        {
            _playerView.OnTriggerEnterChange -= PlayerOnOnTriggerEnterChange;
        }
    }
}