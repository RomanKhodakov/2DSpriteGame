using UnityEngine;

namespace Test2DGame
{
    internal sealed class EnemyFactory: IEnemyFactory
    {
        public EnemyFactory()
        {
        }

        public EnemyView CreateEnemy()
        {
            var res = Resources.Load<EnemyView>($"Enemy/Enemy");
            return res;
        }
    }
}