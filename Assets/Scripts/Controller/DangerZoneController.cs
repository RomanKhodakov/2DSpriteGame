using System.Collections.Generic;
using UnityEngine;

namespace Test2DGame
{
    internal sealed class DangerZoneController : IInitialization, ICleanup
    {
        private readonly DangerZoneView _dangerZoneView;
        private bool _isUnlock = true;
        public bool IsUnlock => _isUnlock;

        public DangerZoneController()
        {
            _dangerZoneView = Object.FindObjectOfType<DangerZoneView>();
        }

        public void Initialization()
        {
            _dangerZoneView.OnLevelObjectLeave += OnLevelObjectLeave;
        }

        private void OnLevelObjectLeave(List<EnemyView> enemyViews)
        {
            foreach (var enemyView in enemyViews)
            {
                _isUnlock = false;
                // enemyView.DestinationSetter.target = null;
            }
        }

        public void Cleanup()
        {
            _dangerZoneView.OnLevelObjectLeave -= OnLevelObjectLeave;
        }
    }
}