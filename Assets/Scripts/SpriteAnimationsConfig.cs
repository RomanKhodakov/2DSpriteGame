using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test2DGame
{
    [CreateAssetMenu(fileName = "SpriteAnimationsConfig", menuName = "Configs/SpriteAnimationsConfig", order = 1)]
    internal class SpriteAnimationsConfig : ScriptableObject
    {
        [SerializeField]
        private List<SpritesSequence> _sequences;
        public List<SpritesSequence> Sequences => _sequences;
    }
}