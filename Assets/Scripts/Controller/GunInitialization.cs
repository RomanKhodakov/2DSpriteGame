using UnityEngine;

namespace Test2DGame
{
    internal sealed class GunInitialization
    {
        private readonly Transform _gunTransform;
        private readonly SpriteRenderer _gunSpriteRenderer;

        public GunInitialization(IGunFactory gunFactory)
        {
            var gunGo = Object.Instantiate(gunFactory.GetGun());
            _gunTransform = gunGo.gameObject.transform;
            _gunSpriteRenderer = gunGo.GetOrAddComponent<SpriteRenderer>();
        }
       
        public Transform GetGunTransform() => _gunTransform;
        public SpriteRenderer GetGunSpriteRenderer() => _gunSpriteRenderer;
    }
}