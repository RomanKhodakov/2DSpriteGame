using UnityEngine;

namespace Test2DGame
{
    internal sealed class InteractiveObjectsInitialization : IInitialization
    {
        private readonly Transform _ioTransform;
        private readonly CheckPointView _checkPoint;

        public InteractiveObjectsInitialization(InteractiveObjectsFactory ioFactory)
        {
            _checkPoint = Object.Instantiate(ioFactory.GetCheckPoint());
            _ioTransform = _checkPoint.gameObject.transform;
        }
        
        public void Initialization()
        {
        }
       
        public Transform GetCheckPointTransform() => _ioTransform;
        public CheckPointView GetCheckPoint() => _checkPoint;
    }
}