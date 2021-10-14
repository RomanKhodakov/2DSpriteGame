using UnityEngine;

namespace Test2DGame
{
    internal class GunRotationController : IExecute
    {
        private readonly Transform _aimTransform;
        private readonly Transform _gunTransform;

        public GunRotationController(Transform aimTransform, Transform gunTransform)
        {
            _aimTransform = aimTransform;
            _gunTransform = gunTransform;
        }


        public void Execute(float deltaTime)
        {
            
            var dir = _aimTransform.position - _gunTransform.position;
            var angle = Vector3.Angle(Vector3.right, dir);
            var axis = Vector3.Cross(Vector3.right, dir);
        
            _gunTransform.rotation = Quaternion.AngleAxis(angle, axis);
        }
    }
    
}
