using UnityEngine;

namespace Test2DGame
{
    internal class Bullet : MonoBehaviour
    {
        private float _time;
        public float Damage { get; private set; }
        public void SelfDestruction(ViewServices<Bullet> viewServices, float time, float lifeTime)
        {
            if (gameObject.activeInHierarchy)
            {
                _time += time;
                if (_time > lifeTime)
                {
                    viewServices.Destroy(this);
                    _time = 0;
                }
            }
            else
            {
                _time = 0;
            }
        }
        
        public void SetDamage(float damage)
        {
            Damage = damage;
        }
    }
}