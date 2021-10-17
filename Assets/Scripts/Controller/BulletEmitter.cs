using System.Collections.Generic;
using UnityEngine;

namespace Test2DGame
{
    internal sealed class BulletEmitter
    {
        private readonly IBulletData _bulletData;
        private readonly IBulletFactory _bulletFactory;
        private readonly ViewServices<Bullet> _viewServices;
        private readonly Dictionary<int, Bullet> _bulletPoolWithID;
        private readonly Transform _gunTransform;
        private readonly float _offset;
        private Vector3 _muzzleOffset;

        public BulletEmitter(IBulletFactory bulletFactory, Transform gunTransform)
        {
            _bulletData = bulletFactory.GetBulletData();
            _bulletFactory = bulletFactory;
            _gunTransform = gunTransform;
            _viewServices = bulletFactory.GetBulletViewServices();
            _bulletPoolWithID = bulletFactory.GetBulletsWithID();
            _offset = _bulletData.Offset;
        }

        public void LaunchBullet()
        {
            var bullet = _viewServices.Instantiate(_bulletFactory.GetBullet());
            var gunRotation = _gunTransform.rotation;
            
            _muzzleOffset.Set(_offset * Mathf.Cos(Mathf.Deg2Rad * gunRotation.eulerAngles.z), 
                _offset * Mathf.Sin(Mathf.Deg2Rad * gunRotation.eulerAngles.z), 0);
            
            bullet.transform.position = _gunTransform.position + _muzzleOffset;
            bullet.transform.rotation = gunRotation * Quaternion.Euler(0, 0, -90f);
            bullet.gameObject.GetOrAddComponent<Rigidbody2D>().AddForce(_gunTransform.right * _bulletData.Speed);
            
            if (!_bulletPoolWithID.ContainsKey(bullet.gameObject.GetInstanceID()))
            {
                _bulletPoolWithID.Add(bullet.gameObject.GetInstanceID(), bullet);
            }
        }
    }
}