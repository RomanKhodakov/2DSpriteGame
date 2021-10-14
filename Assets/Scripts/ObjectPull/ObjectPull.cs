using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Test2DGame
{
    internal sealed class ObjectPull <T> where T : Component
    {
        private readonly Stack <T> _stack = new Stack <T>();
        private readonly T _prefab;
        private readonly Transform _root;

        public ObjectPull(T prefab)
        {
            _root = new GameObject($"[{prefab.name} pull]").transform;
            _prefab = prefab;
        }

        public T Pop()
        {
            T go;
            if (_stack.Count == 0)
            {
                go = Object.Instantiate(_prefab);
                go.name = _prefab.name;
            }
            else
            {
                go = _stack.Pop();
            }
            go.gameObject.SetActive(true);
            go.transform.SetParent(null);
            return go;
        }

        public void Push(T go)
        {
            _stack.Push(go);
            go.transform.SetParent(_root);
            go.gameObject.SetActive(false);
        }
    }
}