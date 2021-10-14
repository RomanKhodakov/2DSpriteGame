using UnityEngine;

namespace Test2DGame
{
    internal sealed class GunInitialization : IInitialization
    {
        private readonly Transform _gunTransform;

        public GunInitialization(GunFactory gunFactory)
        {
            var gunGo = Object.Instantiate(gunFactory.GetGun());
            _gunTransform = gunGo.gameObject.transform;
        }
        
        public void Initialization()
        {
        }
       
        public Transform GetGunTransform() => _gunTransform;
    }
}