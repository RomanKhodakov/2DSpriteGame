using UnityEngine;

namespace Test2DGame
{
    [CreateAssetMenu(fileName = "UnitSettings", menuName = "Data/Unit/UnitSettings")]
    public sealed class PlayerData : ScriptableObject, IUnit
    {
        public SpriteRenderer playerSpriteRenderer;
        [SerializeField] private string _name;
        [SerializeField, Range(0.01f, 3000)] private float _speed;
        [SerializeField, Range(0.01f, 10)] private float _mass;
        public SpriteRenderer SpriteRenderer => playerSpriteRenderer;
        public string Name => _name;
        public float Speed => _speed;
        public float Mass => _mass;
    }
}