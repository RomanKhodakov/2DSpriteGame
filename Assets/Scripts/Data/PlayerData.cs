using UnityEngine;

namespace Test2DGame
{
    [CreateAssetMenu(fileName = "UnitSettings", menuName = "Data/Unit/UnitSettings")]
    public sealed class PlayerData : ScriptableObject, IUnit
    {
        public Sprite playerSprite;
        [SerializeField] private string _name;
        [SerializeField, Range(0.01f, 3000)] private float _speed;
        [SerializeField, Range(0.01f, 10)] private float _mass;
        [SerializeField, Range(0.01f, 10)] private float _colliderRadius;
        public Sprite Sprite => playerSprite;
        public string Name => _name;
        public float Speed => _speed;
        public float Mass => _mass;
        public float ColliderRadius => _colliderRadius;
    }
}