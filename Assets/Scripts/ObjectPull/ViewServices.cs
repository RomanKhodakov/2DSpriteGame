using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Test2DGame
{
    internal sealed class ViewServices<T> where T : Component
    {
        private readonly Dictionary<string, ObjectPull<T>> _viewCashe = new Dictionary<string, ObjectPull<T>>(12);

        public T Instantiate(T prefab)
        {
            if (!_viewCashe.TryGetValue(prefab.name, out var viewPool))
            {
                viewPool = new ObjectPull<T>(prefab);
                _viewCashe[prefab.name] = viewPool;
            }

            var res = viewPool.Pop();

            return res;
        }

        public void Destroy(T value)
        {
            if (!_viewCashe.TryGetValue(value.name, out var viewPool))
            {
                viewPool = new ObjectPull<T>(value);
                _viewCashe[value.name] = viewPool;
            }

            viewPool.Push(value);
        }
    }
}