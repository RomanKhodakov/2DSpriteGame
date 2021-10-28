using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Test2DGame
{
    internal sealed class QuestStory : IQuestStory
    {
        private readonly List<IQuest> _questsCollection;

        public bool IsDone => _questsCollection.All(value => value.IsCompleted);

        public QuestStory(List<IQuest> questsCollection)
        {
            _questsCollection = questsCollection;
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
                Debug.Log("Story done!");
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
