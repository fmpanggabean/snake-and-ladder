using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnakeAndLadder.Gameplay {
    public class Block : MonoBehaviour {
        [SerializeField] private Block nextBlock;

        internal void SetNextBlock(Block block) {
            nextBlock = block;
        }
        public Block GetNextBlock() {
            return nextBlock;
        }

        internal Vector3 GetPosition() {
            return transform.position;
        }

        internal void SetPosition(Vector3 position) {
            transform.position = position;
        }
    } 
}
