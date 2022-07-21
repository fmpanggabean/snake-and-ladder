using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnakeAndLadder.Gameplay
{
    public class BlockEffectSource : MonoBehaviour
    {
        private Block target;
        private Player player;
        public BlockEffectDestination blockEffectDestination;

        private void OnTriggerEnter(Collider collider) {
            Block block = collider.GetComponent<Block>();
            if (block != null) {
                target = block;
            }
            Player p = collider.GetComponent<Player>();
            if (p != null) {
                player = p;
            }
        }
        private void OnTriggerExit(Collider collider) {
            Block block = collider.GetComponent<Block>();
            if (block != null) {
                target = null;
            }
            Player p = collider.GetComponent<Player>();
            if (p != null) {
                player = null;
            }
        }

        internal void Activate() {
            if (player == null) {
                return;
            }
            player.SetPosition(blockEffectDestination.block);
        }
    }
}
