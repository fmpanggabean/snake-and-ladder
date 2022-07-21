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


        private void Awake() {
            Dice.OnDiceThrow += PlayerManager.Move;
            PlayerManager.OnNextTurn += SetTurn;
        }   
        private void Start() {
            //SetTurn(PlayerLabel.Player1);
            PlayerManager.Initialize();
        }
        public void SetTurn(PlayerLabel playerLabel) {
            PlayerManager.SetTurn(playerLabel);
            SetCameraFollow();
        }

        private void SetCameraFollow() {
            CinemachineVirtualCamera.LookAt = PlayerManager.GetCurrentPlayer().transform;
            CinemachineVirtualCamera.Follow = PlayerManager.GetCurrentPlayer().transform;
        }
    }
}
