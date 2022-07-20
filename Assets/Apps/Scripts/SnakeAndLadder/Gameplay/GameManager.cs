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

        private void Start() {
            SetTurn(PlayerLabel.Player1);
        }
        private void Update() {
            //if (Input.GetKeyDown(KeyCode.Alpha1)) {
            //    SetTurn(PlayerLabel.Player1);
            //}
            //else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            //    SetTurn(PlayerLabel.Player2);
            //}
            //else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            //    SetTurn(PlayerLabel.Player3);
            //}
            //else if (Input.GetKeyDown(KeyCode.Alpha4)) {
            //    SetTurn(PlayerLabel.Player4);
            //}
        }
        public void SetTurn(PlayerLabel playerLabel) {
            PlayerManager.SetTurn(playerLabel);
            SetCameraFollow();
        }

        private void SetCameraFollow() {
            CinemachineVirtualCamera.LookAt = PlayerManager.GetCurrentPlayer();
            CinemachineVirtualCamera.Follow = PlayerManager.GetCurrentPlayer();
        }
    }
}
