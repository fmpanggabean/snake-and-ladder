using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnakeAndLadder.Gameplay
{
    public class EffectorBlockDestination : MonoBehaviour
    {
        public Block block;

        protected void OnTriggerEnter(Collider collider) {
            if (collider.GetComponent<Block>()) {
                block = collider.GetComponent<Block>();
            }
        }
        protected void OnTriggerExit(Collider collider) {
            if (collider.GetComponent<Block>()) {
                block = null;
            }
        }
    }
}
