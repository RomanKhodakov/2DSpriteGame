using UnityEngine;

namespace Test2DGame
{
    internal class PlayerView : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;

        public SpriteRenderer SpriteRenderer
        {
            get
            {
                if (!_spriteRenderer) _spriteRenderer = gameObject.GetOrAddComponent<SpriteRenderer>();
                return _spriteRenderer;
            }
        }
    };
}
