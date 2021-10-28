using System.Collections.Generic;
using UnityEngine;

namespace Test2DGame
{
    [CreateAssetMenu(fileName = "QuestItemsConfig", menuName = "QuestConfigs/QuestItemsConfig", order = 1)]
    internal sealed class QuestItemsConfig : ScriptableObject
    {
        [SerializeField] private int _questId;
        [SerializeField] private string _afterEnterText;

        public int QuestId => _questId;
        public string AfterEnterText => _afterEnterText;
    }
}
