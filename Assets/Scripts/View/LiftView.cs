using System;
using UnityEngine;

namespace Test2DGame
{
    internal class LiftView : MonoBehaviour
    {
        private SliderJoint2D _sliderJoint;
        private PlayerView _levelObject;

        public SliderJoint2D SliderJoint
        {
            get
            {
                if (!_sliderJoint) _sliderJoint = gameObject.GetOrAddComponent<SliderJoint2D>();
                return _sliderJoint;
            }
        }
        public Action<SliderJoint2D> OnLevelObjectContact { get; set; }
        public Action<SliderJoint2D> OnLevelObjectLeave { get; set; }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            _levelObject = collider.gameObject.GetComponent<PlayerView>();
        
            if (_levelObject != null)
                OnLevelObjectContact?.Invoke(SliderJoint); 
        }

        private void OnTriggerExit2D(Collider2D collider)
        {
            _levelObject = collider.gameObject.GetComponent<PlayerView>();
        
            if (_levelObject != null)
                OnLevelObjectLeave?.Invoke(SliderJoint); 
        }
    };
}