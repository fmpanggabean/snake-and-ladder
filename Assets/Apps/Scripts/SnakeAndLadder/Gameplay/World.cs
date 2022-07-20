using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnakeAndLadder.Gameplay {
    public class World : MonoBehaviour {

        public GameObject blockPrefab;

        public List<Block> blockList;
        public void CreateBlock(Vector3 offset) {
            Block block = Instantiate(blockPrefab, transform).GetComponent<Block>();
            
            if (blockList.Count > 0) {
                Vector3 newOffset = offset;
                newOffset.y = 0.1f;
                GetLastBlock().SetNextBlock(block);
                block.SetPosition(GetLastBlock().GetPosition() + newOffset);

            }
            blockList.Add(block);
        }

        private Block GetLastBlock() {
            if (blockList.Count <= 0)
                return null;

            return blockList[blockList.Count - 1];
        }

        internal void RemoveLast() {
            Block block = GetLastBlock();
            blockList.Remove(block);
            DestroyImmediate(block.gameObject);

            if (blockList.Count > 0) {
                GetLastBlock().SetNextBlock(null);
            }
        }
    }
}
