using UnityEngine;

namespace Test2DGame
{
    internal class GunPositionController : IExecute
    {
        private readonly Transform _aimTransform;
        private readonly Transform _gunTransform;
        private readonly SpriteRenderer _gunSpriteRenderer;
        private readonly Transform _riflemanTransform;
        private readonly SpriteRenderer _riflemanSpriteRenderer;

        public GunPositionController(Transform aimTransform, GunInitialization gunInitialization, 
            EnemyInitialization enemyInitialization)
        {
            _aimTransform = aimTransform;
            _gunTransform = gunInitialization.GetGunTransform();
            _gunSpriteRenderer = gunInitialization.GetGunSpriteRenderer();
            _riflemanTransform = enemyInitialization.GetEnemyTransform();
            _riflemanSpriteRenderer = enemyInitialization.GetEnemySpriteRenderer();
        }


        public void Execute(float deltaTime)
        {
            var dir = _aimTransform.position - _gunTransform.position;
            var angle = Vector3.Angle(Vector3.right, dir);
            var axis = Vector3.Cross(Vector3.right, dir);
            var isFlip = angle >= 90 && angle <= 180;
            _gunSpriteRenderer.flipY = isFlip;
            _riflemanSpriteRenderer.flipX = isFlip;
            _gunTransform.rotation = Quaternion.AngleAxis(angle, axis);

            _gunTransform.position = _riflemanTransform.position;
        }
    }
}