using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

namespace SnakeAndLadder.Gameplay
{
    public class GameManager : MonoBehaviour
    {
        private PlayerManager PlayerManager => FindObjectOfType<PlayerManager>();
        private CinemachineVirtualCamera CinemachineVirtualCamera => FindObjectOfType<CinemachineVirtualCamera>();
        private Dice Dice => FindObjectOfType<Dice>();

        public event Action<PlayerLabel> OnTurnChanged;


        private void Awake() {
            Dice.OnDiceThrow += PlayerManager.Move;
            //PlayerManager.OnNextTurn += SetTurn;            
        }   
        private void Start() {
            //SetTurn(PlayerLabel.Player1);
            PlayerManager.Initialize();
            SetTurn(PlayerLabel.Player1);
        }
        public void SetTurn(PlayerLabel playerLabel) {
            PlayerManager.SetTurn(playerLabel);
            SetCameraFollow();
            OnTurnChanged?.Invoke(playerLabel);
        }

        private void SetCameraFollow() {
            CinemachineVirtualCamera.LookAt = PlayerManager.GetCurrentPlayer().transform;
            CinemachineVirtualCamera.Follow = PlayerManager.GetCurrentPlayer().transform;
        }
    }
}
