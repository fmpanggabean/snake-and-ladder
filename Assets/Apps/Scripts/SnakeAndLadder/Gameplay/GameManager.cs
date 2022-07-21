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
        private PlayerManager PlayerManager => FindObjectOfType<PlayerManager>();
        private PlayerTurn PlayerTurn = new PlayerTurn();
        private Dice Dice => FindObjectOfType<Dice>();

        public event Action OnGameInitialize;
        public event Action OnGameStart;

        public bool IsPlaying { set; get; }

        private void Awake() {
            OnGameInitialize += Dice.Disable;
            OnGameInitialize += PlayerManager.Initialize;
            OnGameStart += Dice.Enabled;
            Dice.OnDiceEnd += PlayerMove;
            PlayerManager.OnPlayerArrived += PlayerTurn.Next;
            PlayerTurn.OnPlayerTurnSet += Highlight;
        }

        private void Start() {
            OnGameInitialize?.Invoke();

            StartGame();
        }
        private void Update() {
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                PlayerTurn.Next();
            }
        }

        private void StartGame() {
            PlayerTurn.Set(PlayerLabel.Player_1);

            OnGameStart?.Invoke();
        }
        private void PlayerMove(int step) {
            PlayerManager.GetPlayer(PlayerTurn.Current).Move(step);
        }


        private void Highlight(PlayerLabel playerLabel) {
            Debug.Log("Current player: " + playerLabel);
        }
    }
}
