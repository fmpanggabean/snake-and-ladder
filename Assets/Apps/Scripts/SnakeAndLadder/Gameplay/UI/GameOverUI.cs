using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

namespace SnakeAndLadder.Gameplay
{
    public class GameOverUI : MonoBehaviour, IHideShow {
        private GameManager GameManager => FindObjectOfType<GameManager>();

        public GameObject window;
        public TMP_Text messageText;
        public Button toMainMenuButton;

        private void Awake() {
            GameManager.OnGameOver += ShowMessage;
            toMainMenuButton.onClick.AddListener(ToMainMenu);
        }
        private void Start() {
            Hide(window.gameObject);
        }

        private void ToMainMenu() {
            SceneManager.LoadScene(0);
        }
        private void ShowMessage(PlayerLabel playerLabel) {
            Show(window.gameObject);
            messageText.text = playerLabel + " Win!";
        }
        public void Hide(GameObject gameObject) {
            gameObject.SetActive(false);
        }
        public void Show(GameObject gameObject) {
            gameObject.SetActive(true);
        }
    }
}
