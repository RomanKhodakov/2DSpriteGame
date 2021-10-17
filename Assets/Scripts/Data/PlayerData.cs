using UnityEngine;

namespace Test2DGame
{
    [CreateAssetMenu(fileName = "UnitSettings", menuName = "Data/Unit/UnitSettings")]
    public sealed class PlayerData : ScriptableObject, IUnit
    {
        public Sprite playerSprite;
        [SerializeField] private string _name;
        [SerializeField, Range(0.01f, 10)] private float _mass;
        [SerializeField, Range(0.01f, 10)] private float _colliderSizeX;
        [SerializeField, Range(0.01f, 10)] private float _colliderSizeY;
        [SerializeField, Range(0.01f, 3000)] private float _moveSpeed;
        [SerializeField, Range(0.01f, 3000)] private float _animationSpeed;
        [SerializeField, Range(0.01f, 3000)] private float _jumpStartSpeed;
        public Sprite Sprite => playerSprite;
        public string Name => _name;
        public float Mass => _mass;
        public float ColliderSizeX => _colliderSizeX;
        public float ColliderSizeY => _colliderSizeY;
        public float MoveSpeed => _moveSpeed;
        public float AnimationSpeed => _animationSpeed;
        public float JumpStartSpeed => _jumpStartSpeed;
    }
}