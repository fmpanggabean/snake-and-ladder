using System;
using System.Collections.Generic;
using UnityEngine;

namespace SnakeAndLadder.Gameplay
{
    public class EndBlock : MonoBehaviour
    {
        private GameManager GameManager => FindObjectOfType<GameManager>();

        private Player player;

        private event Action<Player> OnReachEndPoint;

        private void Awake() {
            OnReachEndPoint += GameManager.GameOver;
        }

        private void OnTriggerEnter(Collider collider) {
            if (collider.GetComponent<Player>()) {
                player = collider.GetComponent<Player>();

                OnReachEndPoint?.Invoke(player);
            }
        }
    }
}
