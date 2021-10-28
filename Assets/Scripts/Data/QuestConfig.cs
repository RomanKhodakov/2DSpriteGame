using UnityEngine;


namespace Test2DGame
{
    [CreateAssetMenu(fileName = "QuestConfig", menuName = "QuestConfigs/QuestConfig", order = 1)]
    internal sealed class QuestConfig : ScriptableObject
    {
        [SerializeField] private int _id;
        [SerializeField] private QuestType _questType;

        public int Id => _id;
        public QuestType QuestType => _questType;
    }

    internal enum QuestType
    {
        Switch
    }
}
