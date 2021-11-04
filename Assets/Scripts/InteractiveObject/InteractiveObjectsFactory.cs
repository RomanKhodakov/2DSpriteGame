using System.Collections.Generic;
using UnityEngine;

namespace Test2DGame
{
    internal sealed class InteractiveObjectsFactory
    {
        private readonly LiftsReferences _liftsReferences;
        private readonly List<LiftView> _commonLiftsViews;

        public InteractiveObjectsFactory(LiftsReferences liftsReferences)
        {
            _liftsReferences = liftsReferences;
            _commonLiftsViews = new List<LiftView>();
        }

        public CheckPointView GetCheckPoint()
        {
            var res = Resources.Load<CheckPointView>($"InteractiveObjects/CheckPoint");
            return res;
        }
        public DangerZoneView GetDangerZone()
        {
            var res = Resources.Load<DangerZoneView>($"InteractiveObjects/DangerZone");
            return res;
        }
        public List<LiftView> GetCommonLiftsViews()
        {
            foreach (var liftView in _liftsReferences.CommonLiftsViews)
            {
                _commonLiftsViews.Add(liftView);
            }
            return _commonLiftsViews;
        }
        public LiftView GetFinalLiftView() => _liftsReferences.FinalLiftView;
        public Transform GetLiftsViewsRootTransform() => _liftsReferences.RootTransform;
    }
}