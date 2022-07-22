using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace SnakeAndLadder.Gameplay
{
    public class GameManager : MonoBehaviour
    {
        private CinemachineVirtualCamera CinemachineVirtualCamera => FindObjectOfType<CinemachineVirtualCamera>();
        private PlayerManager PlayerManager => FindObjectOfType<PlayerManager>();
        private Dice Dice => FindObjectOfType<Dice>();
        private TurnController TurnController => FindObjectOfType<TurnController>();

        public event Action OnGameInitialize;
        public event Action OnGameStart;
        public event Action<PlayerLabel> OnGameOver;

        public bool IsPlaying { set; get; }


        private void Awake() {
            OnGameInitialize += Dice.Disable;
            OnGameInitialize += PlayerManager.Initialize;
            OnGameStart += Dice.Enabled;
            Dice.OnDiceEnd += PlayerMove;
            PlayerManager.OnPlayerArrived += EvaluateBlock;
        }
        private void Start() {
            OnGameInitialize?.Invoke();

            StartGame();
        }
        private void Update() {
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                TurnController.Next();
            }
        }

        private void EvaluateBlock() {
            if (!IsPlaying) {
                return;
            }
            if (PlayerManager.GetPlayer(TurnController.Current).IsOnEffector()) {
                Debug.Log("Is on effector");
                PlayerManager.GetPlayer(TurnController.Current).ApplyEffector();
            }
            StartCoroutine(DelayedAction(TurnController.Next));
        }
        private IEnumerator DelayedAction(Action action) {
            yield return new WaitForSeconds(0.5f);
            action?.Invoke();
        }
        private void StartGame() {
            IsPlaying = true;
            TurnController.Set(PlayerLabel.Player_1);

            OnGameStart?.Invoke();
        }
        private void PlayerMove(int step) {
            PlayerManager.GetPlayer(TurnController.Current).Move(step);
        }
        public void SetCameraToPlayer(PlayerLabel playerLabel) {
            //set camera to player
            CinemachineVirtualCamera.LookAt = PlayerManager.GetPlayer(playerLabel).transform;
            CinemachineVirtualCamera.Follow = PlayerManager.GetPlayer(playerLabel).transform;
        }
        public void Highlight(PlayerLabel playerLabel) {
            Debug.Log("Current player: " + playerLabel);
        }
        internal void GameOver(Player player) {
            Debug.Log(player + " Reach end point!");
            IsPlaying = false;
            OnGameOver?.Invoke(player.PlayerLabel);
        }
    }
}
