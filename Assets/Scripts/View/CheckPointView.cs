using System;
using UnityEngine;

namespace Test2DGame
{
    internal class CheckPointView : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        private PlayerView _levelObject;

        public SpriteRenderer SpriteRenderer
        {
            get
            {
                if (!_spriteRenderer) _spriteRenderer = gameObject.GetOrAddComponent<SpriteRenderer>();
                return _spriteRenderer;
            }
        }
        public Action<CheckPointView> OnLevelObjectContact { get; set; }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            _levelObject = collider.gameObject.GetComponent<PlayerView>();
        
            if (_levelObject != null)
                OnLevelObjectContact?.Invoke(this); 
        }
    }
}