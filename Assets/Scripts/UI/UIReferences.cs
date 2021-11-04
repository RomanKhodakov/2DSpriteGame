using UnityEngine;
using UnityEngine.UI;

namespace Test2DGame
{
    internal sealed class UIReferences
    {
        private GameObject _questText;
        private GameObject _questHeader;
        private Canvas Canvas { get; }

        public UIReferences(Canvas canvas)
        {
            Canvas = canvas;
        }


        public GameObject QuestText
        {
            get
            {
                if (_questText == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/QuestText");
                    _questText = Object.Instantiate(gameObject, Canvas.transform);
                }

                return _questText;
            }
        }

        public GameObject QuestHeader
        {
            get
            {
                if (_questHeader == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/Header");
                    _questHeader = Object.Instantiate(gameObject, Canvas.transform);
                }

                return _questHeader;
            }
        }

        public Text EndGameText
        {
            get
            {
                var gameObject = Resources.Load<Text>("UI/EndGameText");
                var endGameText = Object.Instantiate(gameObject, Canvas.transform);
                return endGameText;
            }
        }

        public Button MenuButton
        {
            get
            {
                var gameObject = Resources.Load<Button>("UI/MenuButton");
                var menuButton = Object.Instantiate(gameObject, Canvas.transform);
                return menuButton;
            }
        }

        public Button ContinueButton
        {
            get
            {
                var gameObject = Resources.Load<Button>("UI/ContinueButton");
                var continueButton = Object.Instantiate(gameObject, Canvas.transform);
                return continueButton;
            }
        }
    }
}