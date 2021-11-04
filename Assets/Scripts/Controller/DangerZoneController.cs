using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Test2DGame
{
    internal sealed class DangerZoneController : IInitialization, ICleanup
    {
        private readonly DangerZoneView _dangerZoneView;
        private readonly EnemyInitialization _enemyInitialization;
        private readonly Transform _newTargetTransform;
        private readonly Text _questText;
        private const string OnExitText = "Now you can safely search for components. Start with strawberry";
        public bool IsUnlockShooting { get; private set; } = true;

        public DangerZoneController(EnemyInitialization enemyInitialization, 
            InteractiveObjectsInitialization interactiveObjectsInitialization, GameObject questText)
        {
            _enemyInitialization = enemyInitialization;
            _newTargetTransform = interactiveObjectsInitialization.GetCheckPointTransform();
            _dangerZoneView = interactiveObjectsInitialization.GetDangerZone();
            _questText = questText.GetComponentInChildren<Text>();
        }

        public void Initialization()
        {
            _dangerZoneView.OnLevelObjectLeave += OnLevelObjectLeave;
        }

        private void OnLevelObjectLeave()
        {
            if (!IsUnlockShooting) return;
            IsUnlockShooting = false;
            _questText.text = OnExitText;
            _enemyInitialization.GetEnemyDestinationSetter().target = _newTargetTransform;
        }

        public void Cleanup()
        {
            _dangerZoneView.OnLevelObjectLeave -= OnLevelObjectLeave;
        }
    }
}