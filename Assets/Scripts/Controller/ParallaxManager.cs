using UnityEngine;

namespace Test2DGame
{
    internal class ParallaxManager : IExecute
    {
        private readonly Transform _camera;
        private readonly Transform _background;
        private readonly Vector3 _backStartPosition;
        private readonly Vector3 _cameraStartPosition;
        private const float Coef = -0.3f;

        public ParallaxManager(Transform camera, Transform background)
        {
            _camera = camera;
            _background = background;
            _backStartPosition = _background.transform.position;
            _cameraStartPosition = _camera.transform.position;
        }
        public void Execute(float deltaTime)
        {
            _background.position = _backStartPosition + (_camera.position - _cameraStartPosition) * Coef;
        }
    }
}
