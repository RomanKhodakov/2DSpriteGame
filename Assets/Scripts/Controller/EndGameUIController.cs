using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Test2DGame
{
    internal class EndGameUIController : IInitialization
    {
        private const string VictoryEndGameText = "Success!";
        private readonly Text _endGameText;
        private readonly Button _menuButton;
        private readonly Button _continueButton;
        private readonly PlayerView _playerView;

        public EndGameUIController(UIReferences uiReferences, PlayerView playerView)
        {
            _playerView = playerView;
            _endGameText = uiReferences.EndGameText;
            _menuButton = uiReferences.MenuButton;
            _continueButton = uiReferences.ContinueButton;
        }

        public void Initialization()
        {
            HideEndGameUi();
            _menuButton.onClick.AddListener(GoToMenu);
            _continueButton.onClick.AddListener(HideEndGameUi);
        }

        private void HideEndGameUi()
        {
            _endGameText.gameObject.SetActive(false);
            _menuButton.gameObject.SetActive(false);
            _continueButton.gameObject.SetActive(false);
            Time.timeScale = 1.0f;
        }

        private void GoToMenu()
        {
            SceneManager.LoadScene(sceneBuildIndex: 0);
        }

        public void ShowEndGameUi()
        {
            if (!_playerView.IsDead)
            {
                _continueButton.gameObject.SetActive(true);
                _endGameText.text = VictoryEndGameText;
            }
            _endGameText.gameObject.SetActive(true);
            _menuButton.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }
}