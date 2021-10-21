using System.Collections.Generic;

namespace Test2DGame
{
    internal interface IEnemyFactory
    {
        public EnemyView CreateEnemy();
    }
}