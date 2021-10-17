using System.Collections.Generic;
using UnityEngine;

namespace Test2DGame
{
    internal sealed class BulletFactory: IBulletFactory
    {
        private readonly IBulletData _playerBulletData;
        private readonly ViewServices<Bullet> _bulletViewServices;
        private readonly Dictionary<int, Bullet> _bulletPoolWithID;

        public BulletFactory(IBulletData playerBulletData)
        {
            _playerBulletData = playerBulletData;
            _bulletViewServices = new ViewServices<Bullet>();
            _bulletPoolWithID = new Dictionary<int, Bullet>();
        }
        
        public Bullet GetBullet()
        {
            var res = Resources.Load<Bullet>($"Bullet/{_playerBulletData.Name}");
            res.gameObject.AddRigidbody2D(_playerBulletData.Mass).AddCircleCollider2D();
            return res;
        }
        
        public IBulletData GetBulletData()
        {
            return _playerBulletData;
        }

        public ViewServices<Bullet> GetBulletViewServices()
        {
            return _bulletViewServices;
        }

        public Dictionary<int, Bullet> GetBulletsWithID()
        {
            return _bulletPoolWithID;
        }
    }
}