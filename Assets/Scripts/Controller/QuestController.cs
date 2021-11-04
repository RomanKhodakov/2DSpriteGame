using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Test2DGame
{
    internal sealed class QuestController : IInitialization, ICleanup
    {
        private readonly QuestStoryConfig[] _questStoryConfigs;
        private readonly QuestItemsConfig[] _questItemsConfigs;
        private readonly List<QuestObjectView> _questObjectsViews;
        private readonly Text _questText;
        private readonly Text _questHeader;

        public QuestController(QuestReferences questReferences, List<QuestObjectView> questObjectsViews, UIReferences uiReferences)
        {
            _questStoryConfigs = questReferences.QuestStoryConfigs;
            _questItemsConfigs = questReferences.QuestItemsConfigs;
            _questObjectsViews = questObjectsViews;
            _questText = uiReferences.QuestText.GetComponentInChildren<Text>();
            _questHeader = uiReferences.QuestHeader.GetComponentInChildren<Text>();
        }

        private List<IQuestStory> _questStories;
        
        private readonly Dictionary<QuestType, Func<IQuestModel>> _questFactories =
            new Dictionary<QuestType, Func<IQuestModel>>
            {
                {QuestType.Switch, () => new SwitchQuestModel()},
            };

        private readonly Dictionary<QuestStoryType, Func<List<IQuest>, Text, Text, IQuestStory>> _questStoryFactories =
            new Dictionary<QuestStoryType, Func<List<IQuest>, Text, Text, IQuestStory>>
            {
                {QuestStoryType.Common, (questCollection, questHeader, questText) => 
                    new QuestStory(questCollection, questHeader)},
                {QuestStoryType.Resettable, (questCollection, questHeader, questText) => 
                    new ResettableQuestStory(questCollection, questHeader, questText)}
            };


        public void Initialization()
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

            return _questStoryFactories[storyConfig.QuestStoryType].Invoke(quests, _questHeader, _questText);
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
                return new Quest(questObjectView, questModel, questItemConfig, _questText);
            }

            Debug.LogWarning($"QuestsConfigurator :: Start : Can't create model for quest {questId.ToString()}");
            return null;
        }
        public bool IsAllQuestsStoriesDone()
        {
            return _questStories.All(value => value.IsDone);
        }

        public void Cleanup()
        {
            foreach (var questStory in _questStories)
                questStory.Dispose();
        }
    }
}