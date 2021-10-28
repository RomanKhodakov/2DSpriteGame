using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Test2DGame
{
    internal sealed class QuestConfigurator : MonoBehaviour
    {
        [SerializeField] private QuestStoryConfig[] _questStoryConfigs;
        [SerializeField] private QuestObjectView[] _questObjectsViews;
        [SerializeField] private QuestItemsConfig[] _questItemsConfigs;

        private List<IQuestStory> _questStories;
        
        private readonly Dictionary<QuestType, Func<IQuestModel>> _questFactories =
            new Dictionary<QuestType, Func<IQuestModel>>
            {
                {QuestType.Switch, () => new SwitchQuestModel()},
            };

        private readonly Dictionary<QuestStoryType, Func<List<IQuest>, IQuestStory>> _questStoryFactories =
            new Dictionary<QuestStoryType, Func<List<IQuest>, IQuestStory>>
            {
                {QuestStoryType.Common, questCollection => new QuestStory(questCollection)},
                {QuestStoryType.Resettable, questCollection => new ResettableQuestStory(questCollection)}
            };
        
        private void Start()
        {
            _questStories = new List<IQuestStory>();

            foreach (var questStoryConfig in _questStoryConfigs)
                _questStories.Add(CreateQuestStory(questStoryConfig));
        }
        
        private IQuestStory CreateQuestStory(QuestStoryConfig storyConfig)
        { 
            var quests = new List<IQuest>();

            foreach (var questConfig in storyConfig.QuestsConfigs)
            {
                var quest = CreateQuest(questConfig);

                if (quest == null)
                    continue;

                quests.Add(quest);
            }

            return _questStoryFactories[storyConfig.QuestStoryType].Invoke(quests);
        }

        private IQuest CreateQuest(QuestConfig questConfig)
        { 
            
            var questId = questConfig.Id;
            
            var questObjectView = _questObjectsViews.FirstOrDefault(value => value.Id == questConfig.Id);
            if (questObjectView == null)
            {
                Debug.LogWarning($"QuestsConfigurator :: Start : Can't find view of quest {questId.ToString()}");
                return null;
            } 
            var questItemConfig = _questItemsConfigs.FirstOrDefault(value => value.QuestId == questConfig.Id);
            if (questItemConfig == null)
            {
                Debug.LogWarning($"QuestsConfigurator :: Start : Can't find items of quest {questId.ToString()}");
                return null;
            }

            if (_questFactories.TryGetValue(questConfig.QuestType, out var modelFactory))
            {
                var questModel = modelFactory.Invoke();
                return new Quest(questObjectView, questModel, questItemConfig);
            }

            Debug.LogWarning($"QuestsConfigurator :: Start : Can't create model for quest {questId.ToString()}");
            return null;
        }

        public void Dispose()
        {
            foreach (var questStory in _questStories)
                questStory.Dispose();
        }
    }
}