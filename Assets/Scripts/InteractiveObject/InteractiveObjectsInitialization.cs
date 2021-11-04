using System.Collections.Generic;
using UnityEngine;

namespace Test2DGame
{
    internal sealed class InteractiveObjectsInitialization
    {
        private readonly CheckPointView _checkPoint;
        private readonly DangerZoneView _dangerZone;
        private readonly List<LiftView> _commonLiftsViews;
        private readonly LiftView _finalLiftView;
        private readonly Transform _checkPointTransform;

        public InteractiveObjectsInitialization(InteractiveObjectsFactory ioFactory)
        {
            _commonLiftsViews = new List<LiftView>();
            var liftRootTransform = Object.Instantiate(ioFactory.GetLiftsViewsRootTransform());
            _checkPoint = Object.Instantiate(ioFactory.GetCheckPoint());
            _dangerZone = Object.Instantiate(ioFactory.GetDangerZone());
            foreach (var liftView in ioFactory.GetCommonLiftsViews())
            {
                _commonLiftsViews.Add(Object.Instantiate(liftView, liftRootTransform));
            }
            _finalLiftView = Object.Instantiate(ioFactory.GetFinalLiftView(), liftRootTransform);
            _checkPointTransform = _checkPoint.gameObject.transform;
        }
       
        public Transform GetCheckPointTransform() => _checkPointTransform;
        public CheckPointView GetCheckPoint() => _checkPoint;
        public DangerZoneView GetDangerZone() => _dangerZone;
        public LiftView GetFinalLiftView() => _finalLiftView;
        public List<LiftView> GetCommonLiftsViews() => _commonLiftsViews;
    }
}