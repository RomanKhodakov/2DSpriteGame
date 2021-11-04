using System.Collections.Generic;
using UnityEngine;

namespace Test2DGame
{
    internal class CheckPointController : IInitialization, ICleanup
    {
        private readonly List<CheckPointView> _checkPontViews;
        private readonly EndGameUIController _endGameUIController;

        public CheckPointController(List<CheckPointView> checkPontViews, EndGameUIController endGameUIController)
        {
            _checkPontViews = checkPontViews;
            _endGameUIController = endGameUIController;
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
                _endGameUIController.ShowEndGameUi();
            }
        }

        public void Cleanup()
        {
            foreach (var checkPointView in _checkPontViews)
                checkPointView.OnLevelObjectContact -= OnLevelObjectContact;
        }
    }
}
