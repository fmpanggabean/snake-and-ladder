using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace SnakeAndLadder.Menu
{
    public class StartGameUI : MonoBehaviour
    {
        public PersistentData PersistentData;

        public Button play2Button;
        public Button play3Button;
        public Button play4Button;

        private void Awake() {
            play2Button.onClick.AddListener(Start2Player);
            play3Button.onClick.AddListener(Start3Player);
            play4Button.onClick.AddListener(Start4Player);
        }

        private void Start4Player() {
            PersistentData.playerCount = 4;
            StartGame();
        }

        private void Start3Player() {
            PersistentData.playerCount = 3;
            StartGame();
        }

        private void Start2Player() {
            PersistentData.playerCount = 2;
            StartGame();
        }
        private void StartGame() {
            SceneManager.LoadScene(1);
        }
    }
}
