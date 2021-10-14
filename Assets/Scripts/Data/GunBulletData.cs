using UnityEngine;

namespace Test2DGame
{
    [CreateAssetMenu(fileName = "BulletSettings", menuName = "Data/Unit/BulletSettings")]
    internal sealed class GunBulletData : ScriptableObject, IBulletData
    {
        [SerializeField] private string _name;
        [SerializeField, Range(0.01f, 10)] private float _speed;
        [SerializeField, Range(1, 200)] private float _damage;
        [SerializeField, Range(0.01f, 10)] private float _mass;
        [SerializeField, Range(0.01f, 10)] private float _offset;
        [SerializeField, Range(1, 10)] private float _lifeTime;
        [SerializeField, Range(10, 30)] private int _baseBulletPullCount;
        public string Name => _name;
        public float Speed => _speed;
        public float Damage => _damage;
        public float Mass => _mass;
        public float Offset => _offset;
        public float LifeTime => _lifeTime;
        public int BaseBulletPullCount => _baseBulletPullCount;
    }
}