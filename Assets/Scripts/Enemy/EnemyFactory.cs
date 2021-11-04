using UnityEngine;

namespace Test2DGame
{
    internal sealed class EnemyFactory: IEnemyFactory
    {
        public EnemyView CreateEnemy()
        {
            var res = Resources.Load<EnemyView>($"Enemy/Enemy");
            return res;
        }
    }
}