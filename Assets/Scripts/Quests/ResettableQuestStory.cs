using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

namespace Test2DGame
{
    internal sealed class ResettableQuestStory : IQuestStory
    {
        private readonly List<IQuest> _questsCollection;
        private readonly Text _questHeader;
        private readonly Text _questText;
        private const string OnCompletedText = "Completed!";
        private const string OnResetText = "Everything is messed up. Gotta start over";
        private int _currentIndex;

        public bool IsDone => _questsCollection.All(value => value.IsCompleted);

        public ResettableQuestStory(List<IQuest> questsCollection, Text questHeader, Text questText)
        {
            _questsCollection = questsCollection;
            _questHeader = questHeader;
            _questText = questText;
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
                    _questHeader.text = OnCompletedText;
            }
            else
            {
                ResetQuests();
                _questText.text = OnResetText;
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
                quest.Dispose();
            }
        }

        public void Dispose()
        {
            Unsubscribe();
        }
    }
}
