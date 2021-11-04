using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Test2DGame
{
    internal sealed class QuestStory : IQuestStory
    {
        private readonly List<IQuest> _questsCollection;
        private readonly Text _questHeader;
        private const string OnCompletedText = "Всё собрано!";

        public bool IsDone => _questsCollection.All(value => value.IsCompleted);

        public QuestStory(List<IQuest> questsCollection, Text questHeader)
        {
            _questsCollection = questsCollection;
            _questHeader = questHeader;
            Subscribe();
            ResetQuest(0);
        }

        private void Subscribe()
        {
            foreach (var quest in _questsCollection)
                quest.Completed += OnQuestCompleted;
        }

        private void ResetQuest(int index)
        {
            if (index < 0 || index >= _questsCollection.Count)
                return;

            var currentQuest = _questsCollection[index];

            if (currentQuest.IsCompleted)
                OnQuestCompleted(currentQuest);
            else
                _questsCollection[index].Reset();
        }

        private void OnQuestCompleted(IQuest completedQuest)
        {
            var completedQuestIndex = _questsCollection.IndexOf(completedQuest);

            if (IsDone)
                _questHeader.text = OnCompletedText;
            else
                ResetQuest(++completedQuestIndex);
        }
        

        public void Dispose()
        {
            foreach (var quest in _questsCollection)
                quest.Completed -= OnQuestCompleted;
        }
    }
}
