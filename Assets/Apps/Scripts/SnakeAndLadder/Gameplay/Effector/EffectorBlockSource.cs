using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnakeAndLadder.Gameplay
{
    public class EffectorBlockSource : EffectorBlockDestination {
        [SerializeField]
        private Player player;
        [SerializeField]
        private EffectorBlockDestination EffectorBlockDestination;

        private new void OnTriggerEnter(Collider collider) {
            base.OnTriggerEnter(collider);

            if (collider.GetComponent<Player>()) {
                player = collider.GetComponent<Player>();
            }
        }
        private new void OnTriggerExit(Collider collider) {
            base.OnTriggerExit(collider);

            if (collider.GetComponent<Player>()) {
                player = null;
            }
        }
        public Block GetDestination() {
            return EffectorBlockDestination.block;
        }
    }
}
