using System;
using UnityEngine;

namespace Test2DGame
{
    internal sealed class Quest : IQuest
    {
        private readonly QuestObjectView _questView;
        private readonly IQuestModel _questModel;
        private readonly QuestItemsConfig _questItemsConfig;
        private bool _isActive;

        public bool IsCompleted { get; private set; }

        public event Action<IQuest> Completed;


        public Quest(QuestObjectView questObjectView, IQuestModel questModel, QuestItemsConfig questItemsConfig)
        {
            _questView = questObjectView;
            _questModel = questModel;
            _questItemsConfig = questItemsConfig;
        }

        public void Reset()
        {
            if (_isActive)
                return;

            _isActive = true;
            IsCompleted = false;
            _questView.OnLevelObjectEnter += OnContact;
            _questView.ActivateQuestObject();
        }

        private void OnContact(PlayerView characterView)
        {
            var completed = _questModel.TryComplete(characterView.gameObject);

            if (completed)
            {
                Complete();
            }
        }

        private void Complete()
        {
            if (!_isActive)
                return;

            _isActive = false;
            IsCompleted = true;
            _questView.OnLevelObjectEnter -= OnContact;
            _questView.AfterQuestCompleted();
            Debug.Log(_questItemsConfig.AfterEnterText);
            OnCompleted();
        }

        private void OnCompleted()
        {
            Completed?.Invoke(this);
        }

        public void Dispose()
        {
            _questView.OnLevelObjectEnter -= OnContact;
        }
    }
}
