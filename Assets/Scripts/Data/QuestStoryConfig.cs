using UnityEngine;

namespace Test2DGame
{
    [CreateAssetMenu(fileName = "QuestStoryConfig", menuName = "QuestConfigs/QuestStoryConfig", order = 1)]
    internal sealed class QuestStoryConfig : ScriptableObject
    {
        [SerializeField] private QuestConfig[] _questsConfigs;
        [SerializeField] private QuestStoryType _questStoryType;

        public QuestConfig[] QuestsConfigs => _questsConfigs;
        public QuestStoryType QuestStoryType => _questStoryType;
    }

    public enum QuestStoryType
    {
        Common,
        Resettable
    }
}
