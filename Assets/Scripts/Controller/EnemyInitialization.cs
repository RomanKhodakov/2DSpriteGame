using Pathfinding;
using UnityEngine;

namespace Test2DGame
{
    internal sealed class EnemyInitialization : IInitialization
    {
        private readonly Transform _enemyTransform;
        private readonly SpriteRenderer _enemySpriteRenderer;
        private readonly AIDestinationSetter _enemyDestinationSetter;
        private readonly Transform _aimTarget;

        public EnemyInitialization(IEnemyFactory enemyFactory, Transform aimTarget)
        {
            var enemyView = Object.Instantiate(enemyFactory.CreateEnemy());
            _enemyTransform = enemyView.gameObject.transform;
            _enemySpriteRenderer = enemyView.gameObject.GetOrAddComponent<SpriteRenderer>();
            _enemyDestinationSetter = enemyView.DestinationSetter;
            _aimTarget = aimTarget;
        }
        
        public void Initialization()
        {
            _enemyDestinationSetter.target = _aimTarget;
        }
       
        public Transform GetEnemyTransform() => _enemyTransform;
        public SpriteRenderer GetEnemySpriteRenderer() => _enemySpriteRenderer;
        public AIDestinationSetter GetEnemyDestinationSetter() => _enemyDestinationSetter;
    }
}