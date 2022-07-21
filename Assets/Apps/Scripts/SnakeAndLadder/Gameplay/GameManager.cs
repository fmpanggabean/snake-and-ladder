using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnakeAndLadder.Gameplay
{
    public static class PersistentData {
        public static int playerQuantity = 4;
    }
    public class GameManager : MonoBehaviour
    {
        public event Action OnGameStarted;

        public bool IsPlaying { set; get; }

        private void Start() {
            StartGame();
        }

        private void StartGame() {
            IsPlaying = true;

            OnGameStarted?.Invoke();
        }
    }
}
