using System;
using System.Collections.Generic;
using UnityEngine;

namespace Test2DGame
{
    internal class DangerZoneView : MonoBehaviour
    {
        private PlayerView _levelObject;
        private readonly List<EnemyView> _enemiesObjects = new List<EnemyView>();
        public Action<List<EnemyView>> OnLevelObjectLeave { get; set; }
        
        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (!_enemiesObjects.Contains(collider.gameObject.GetComponent<EnemyView>()))
            {
                _enemiesObjects.Add(collider.gameObject.GetComponent<EnemyView>());
            }
        }

        private void OnTriggerExit2D(Collider2D collider)
        {
            _levelObject = collider.gameObject.GetComponent<PlayerView>();
        
            if (_levelObject != null)
                OnLevelObjectLeave?.Invoke(_enemiesObjects); 
        }
    }
}
