using System.Collections.Generic;

namespace Test2DGame
{
    internal interface IBulletFactory
    {
        public Bullet GetBullet();
        public IBulletData GetBulletData();
        public ViewServices<Bullet> GetBulletViewServices();
        public Dictionary<int, Bullet> GetBulletsWithID();
    }
}