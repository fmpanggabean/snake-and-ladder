using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SnakeAndLadder.Gameplay
{
    public class GameOverUI : MonoBehaviour, IHideShow {
        private GameManager GameManager => FindObjectOfType<GameManager>();

        public GameObject window;
        public TMP_Text messageText;

        private void Awake() {
            GameManager.OnGameOver += ShowMessage;
        }
        private void Start() {
            Hide(window.gameObject);
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
