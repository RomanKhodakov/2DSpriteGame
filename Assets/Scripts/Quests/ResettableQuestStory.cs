using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Test2DGame
{
    internal sealed class ResettableQuestStory : IQuestStory
    {
        private readonly List<IQuest> _questsCollection;
        private int _currentIndex;

        public bool IsDone => _questsCollection.All(value => value.IsCompleted);

        public ResettableQuestStory(List<IQuest> questsCollection)
        {
            _questsCollection = questsCollection;
            Subscribe();
            ResetQuests();
        }

        private void Subscribe()
        {
            foreach (var quest in _questsCollection)
            {
                quest.Completed += OnQuestCompleted;
            }
        }

        private void OnQuestCompleted(IQuest quest)
        {
            var index = _questsCollection.IndexOf(quest);

            if (_currentIndex == index)
            {
                _currentIndex++;

                if (IsDone)
                    Debug.Log("Story done!");
            }
            else
            {
                ResetQuests();
            }
        }

        private void ResetQuests()
        {
            _currentIndex = 0;
            foreach (var quest in _questsCollection)
            {
                quest.Reset();
            }
        }
        
        private void Unsubscribe()
        {
            foreach (var quest in _questsCollection)
            {
                quest.Completed -= OnQuestCompleted;
            }
        }

        public void Dispose()
        {
            Unsubscribe();
        }
    }
}
