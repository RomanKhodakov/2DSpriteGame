using System.Collections.Generic;
using UnityEngine;

namespace Test2DGame
{
    internal sealed class BulletEmitter
    {
        private readonly IBulletData _bulletData;
        private readonly BulletFactory _bulletFactory;
        private readonly ViewServices<Bullet> _viewServices;
        private readonly Dictionary<int, Bullet> _bulletPoolWithID;
        private readonly Transform _gunTransform;
        private readonly Vector3 _muzzleOffset;

        public BulletEmitter(BulletFactory bulletFactory, Transform gunTransform)
        {
            _bulletData = bulletFactory.GetBulletData();
            _bulletFactory = bulletFactory;
            _gunTransform = gunTransform;
            _viewServices = bulletFactory.GetBulletViewServices();
            _bulletPoolWithID = bulletFactory.GetBulletsWithID();
            _muzzleOffset.Set(_bulletData.Offset, 0, 0);
        }

        public void LaunchBullet()
        {
            var bullet = _viewServices.Instantiate(_bulletFactory.GetBullet());
            bullet.transform.position = _gunTransform.position + _muzzleOffset;
            bullet.gameObject.GetOrAddComponent<Rigidbody2D>().AddForce(_gunTransform.right * _bulletData.Speed);
            
            if (!_bulletPoolWithID.ContainsKey(bullet.gameObject.GetInstanceID()))
            {
                _bulletPoolWithID.Add(bullet.gameObject.GetInstanceID(), bullet);
            }
        }
    }
}