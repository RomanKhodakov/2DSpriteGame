using System.Collections.Generic;
using UnityEngine;

namespace Test2DGame
{
    internal class CheckPointController : IInitialization, ICleanup
    {
        private readonly List<CheckPointView> _checkPontViews;

        public CheckPointController(List<CheckPointView> checkPontViews)
        {
            _checkPontViews = checkPontViews;
        }

        public void Initialization()
        {
            foreach (var checkPointView in _checkPontViews)
                checkPointView.OnLevelObjectContact += OnLevelObjectContact;
        }

        private void OnLevelObjectContact(CheckPointView checkPointView)
        {
            if (_checkPontViews.Contains(checkPointView))
            {
                Object.Destroy(checkPointView.gameObject);
                Debug.Log("End Game");
            }
        }

        public void Cleanup()
        {
            foreach (var checkPointView in _checkPontViews)
                checkPointView.OnLevelObjectContact -= OnLevelObjectContact;
        }
    }
    
}
