using UnityEngine;

namespace Test2DGame
{
    public sealed class GameStarter : MonoBehaviour
    {
        [SerializeField] private Data _data;
        [SerializeField] private Canvas _canvas;
        private Controllers _controllers;
        
        private void Start()
        {
            _controllers = new Controllers();
            new GameInitialization(_controllers, _data, _canvas);
            _controllers.Initialization();
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _controllers.Execute(deltaTime);
        }
        private void FixedUpdate()
        {
            var fixedDeltaTime = Time.fixedDeltaTime;
            _controllers.FixedExecute(fixedDeltaTime);
        }

        private void LateUpdate()
        {
            var deltaTime = Time.deltaTime;
            _controllers.LateExecute(deltaTime);
        }

        private void OnDestroy()
        {
            _controllers.Cleanup();
        }
    }
}