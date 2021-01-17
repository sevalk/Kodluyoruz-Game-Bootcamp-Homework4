using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UISystems
{
    public class MainMenuPanelController : GenericUIPanelController
    {

        /*
         
         * scoreboard -> menu kapansın, scoreboard açılsın, scoreboard kapansın menu geri açılsın
         * settings -> settings açılsın, ordan da başka settingsler açılsın ->menu geri açılsın, settings oyunda da açılsın
         */
         //private 

        [SerializeField]
        private Button _startGameButton;
        [SerializeField]
        private Button _scoreBoardButton;
        [SerializeField]
        private Button _settingsButton;
        [SerializeField]
        private Button _creditsButton;

        private ExampleSceneLoader _exampleSceneLoader;


        private void Start()
        {
            _exampleSceneLoader = FindObjectOfType<ExampleSceneLoader>();

            _startGameButton.onClick.AddListener(StartButtonFunction);
            _scoreBoardButton.onClick.AddListener(ScoreBoardButtonFunction);
            _settingsButton.onClick.AddListener(SettingsButtonFunction);
            _creditsButton.onClick.AddListener(CreditsButtonFunction);

            UIManager.Instance().currentUIPanelController = this;
        }


        #region Button Functions
        private void StartButtonFunction()
        {
            _exampleSceneLoader.LoadGameScene();
        }

        private void ScoreBoardButtonFunction()
        {
            ClosePanel();
            UIManager.Instance().OpenPanel(UIPanelTypes.scoreBoard, true);
        }

        private void SettingsButtonFunction()
        {
            ClosePanel();
            UIManager.Instance().OpenPanel(UIPanelTypes.settingsPanel, true);

        }

        private void CreditsButtonFunction()
        {
            ClosePanel();
            UIManager.Instance().OpenPanel(UIPanelTypes.creditsPanel, false);

        }
        #endregion

        public override void ClosePanel()
        {
            this.gameObject.SetActive(false);
        }

        public override void OpenPanel()
        {
            this.gameObject.SetActive(true);
        }
    }
}

