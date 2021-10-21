using UnityEngine;

namespace Test2DGame
{
    internal sealed class GunShootProxy : IExecute
    {
        private readonly GunShootController _gunShootController;
        private readonly DangerZoneController _dangerZoneController;

        public GunShootProxy(GunShootController gunShootController, DangerZoneController dangerZoneController)
        {
            _gunShootController = gunShootController;
            _dangerZoneController = dangerZoneController;
        }

        public void Execute(float deltaTime)
        {
            if (_dangerZoneController.IsUnlock)
            {
                _gunShootController.Execute(deltaTime);
            }
        }
    }
}