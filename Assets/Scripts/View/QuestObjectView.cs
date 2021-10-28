using System;
using UnityEngine;

namespace Test2DGame
{
    internal sealed class QuestObjectView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Color _completedColor;
        [SerializeField] private int _id;

        private Color _defaultColor;

        public int Id => _id;

        public Action<PlayerView> OnLevelObjectEnter { get; set; }

        private void Awake()
        {
            _defaultColor = _spriteRenderer.color;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var characterView = collision.gameObject.GetComponent<PlayerView>();

            if (characterView != null)
                OnLevelObjectEnter?.Invoke(characterView);
        }

        public void AfterQuestCompleted()
        {
            _spriteRenderer.color = _completedColor;
        }

        public void ActivateQuestObject()
        {
            _spriteRenderer.color = _defaultColor;
        }
    }
}