using System.Collections.Generic;
using UnityEngine;

namespace Test2DGame
{
    internal sealed class QuestObjectsInitialization
    {
        private readonly List<QuestObjectView> _questObjectsViewsInstantiated;


        public QuestObjectsInitialization(QuestObjectView[] questObjectsViews)
        {
            _questObjectsViewsInstantiated = new List<QuestObjectView>();
            foreach (var questObjectView in questObjectsViews)
            {
                var questObjects = Object.Instantiate(questObjectView);
                _questObjectsViewsInstantiated.Add(questObjects);
            }
        }
        
        public List<QuestObjectView> QuestObjectsViews => _questObjectsViewsInstantiated;
    }
}