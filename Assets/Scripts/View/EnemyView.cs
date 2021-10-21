using System;
using Pathfinding;
using UnityEngine;

namespace Test2DGame
{
    internal class EnemyView : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        private AIDestinationSetter _destinationSetter;

        public SpriteRenderer SpriteRenderer
        {
            get
            {
                if (!_spriteRenderer) _spriteRenderer = gameObject.GetOrAddComponent<SpriteRenderer>();
                return _spriteRenderer;
            }
        }
        
        public AIDestinationSetter DestinationSetter
        {
            get
            {
                if (!_destinationSetter) _destinationSetter = gameObject.GetOrAddComponent<AIDestinationSetter>();
                return _destinationSetter;
            }
        }
    }
}