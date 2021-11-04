using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;

namespace Test2DGame
{
    internal sealed class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _mainMenu;
        [SerializeField] private GameObject _settingsMenu;
        [SerializeField] private Text _firstSettingsText;
        [SerializeField] private Text _secondSettingsText;

        private void Awake()
        {
            _settingsMenu.SetActive(false);
            _mainMenu.SetActive(true);
        }

        public void ShowSettings()
        {
            _settingsMenu.SetActive(true);
            _mainMenu.SetActive(false);
        }
        
        public void FistSettingsButton()
        {
            _firstSettingsText.text = ":)";
        }
        public void SecondSettingsButton()
        {
            _secondSettingsText.text = ";)";
        }

        public void ShowMain()
        {
            _settingsMenu.SetActive(false);
            _mainMenu.SetActive(true);
        }

        public void StartGame()
        {
            SceneManager.LoadScene(1);
        }

        public void Exit()
        {
            Application.Quit();
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#endif
        }
    }
}
