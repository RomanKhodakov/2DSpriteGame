using UnityEngine;

namespace Test2DGame
{
    [CreateAssetMenu(fileName = "QuestReferences", menuName = "Data/QuestReferences")]
    internal sealed class QuestReferences : ScriptableObject
    {
        [SerializeField] private QuestStoryConfig[] _questStoryConfigs;
        [SerializeField] private QuestObjectView[] _questObjectsViews;
        [SerializeField] private QuestItemsConfig[] _questItemsConfigs;

        public QuestStoryConfig[] QuestStoryConfigs => _questStoryConfigs;
        public QuestObjectView[] QuestObjectsViews => _questObjectsViews;
        public QuestItemsConfig[] QuestItemsConfigs => _questItemsConfigs;
    }
}