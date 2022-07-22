using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SnakeAndLadder.Gameplay {
    public class World : MonoBehaviour {
        [SerializeField]
        private GameObject blockPrefab;
        [SerializeField]
        private List<Block> blockList;

        public Block GetBlock(int index) {
            return blockList[index];
        }

#if UNITY_EDITOR
        public void ClearBlock() {
            int blockCount = blockList.Count;
            for (int i=0; i<blockCount; i++) {
                RemoveLast();
            }
        }
        public void CreateBlock(Vector3 offset) {
            Block block = Instantiate(blockPrefab, transform).GetComponent<Block>();
            //GameObject gameObject = (GameObject)PrefabUtility.InstantiatePrefab(blockPrefab, transform);
            //Block block = gameObject.GetComponent<Block>();
            
            if (blockList.Count > 0) {
                Vector3 newOffset = offset;
                newOffset.y = 0.01f;
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
#endif
    }
}
