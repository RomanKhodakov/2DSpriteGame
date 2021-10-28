using System.Collections.Generic;
using UnityEngine;

namespace Test2DGame
{
    internal sealed class DangerZoneController : IInitialization, ICleanup
    {
        private readonly DangerZoneView _dangerZoneView;
        private readonly EnemyInitialization _enemyInitialization;
        private bool _isUnlock = true;
        public bool IsUnlock => _isUnlock;

        public DangerZoneController(EnemyInitialization enemyInitialization)
        {
            _enemyInitialization = enemyInitialization;
            _dangerZoneView = Object.FindObjectOfType<DangerZoneView>();
        }

        public void Initialization()
        {
            _dangerZoneView.OnLevelObjectLeave += OnLevelObjectLeave;
        }

        private void OnLevelObjectLeave()
        {
            _isUnlock = false;
            _enemyInitialization.GetEnemyDestinationSetter().target = null;
        }

        public void Cleanup()
        {
            _dangerZoneView.OnLevelObjectLeave -= OnLevelObjectLeave;
        }
    }
}