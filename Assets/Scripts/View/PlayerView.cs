using System;
using UnityEngine;

namespace Test2DGame
{
    internal class PlayerView : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        public bool IsDead;

        public SpriteRenderer SpriteRenderer
        {
            get
            {
                if (!_spriteRenderer) _spriteRenderer = gameObject.GetOrAddComponent<SpriteRenderer>();
                return _spriteRenderer;
            }
        }
        public event Action<int> OnTriggerEnterChange;

        private void OnTriggerEnter2D(Collider2D other)
        {
            OnTriggerEnterChange?.Invoke(other.gameObject.GetInstanceID());
        }
    }
}
