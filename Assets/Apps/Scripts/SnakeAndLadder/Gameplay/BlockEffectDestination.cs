using UnityEngine;
using System;

namespace SnakeAndLadder.Gameplay {
    public class BlockEffectDestination :  MonoBehaviour{
        public Block block;

        private void OnTriggerEnter(Collider other) {
            Block b = other.GetComponent<Block>();

            if (b != null) {
                block = b;
            }
        }
        private void OnTriggerExit(Collider other) {
            Block b = other.GetComponent<Block>();

            if (b != null) {
                block = null;
            }
        }
    }
}