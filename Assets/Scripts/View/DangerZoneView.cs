using System;
using System.Collections.Generic;
using UnityEngine;

namespace Test2DGame
{
    internal class DangerZoneView : MonoBehaviour
    {
        private PlayerView _levelObject;
        public Action OnLevelObjectLeave { get; set; }
        
        private void OnTriggerExit2D(Collider2D collider)
        {
            _levelObject = collider.gameObject.GetComponent<PlayerView>();
        
            if (_levelObject != null)
                OnLevelObjectLeave?.Invoke(); 
        }
    }
}
