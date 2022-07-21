using System;
using UnityEngine;
using System.Collections.Generic;

namespace SnakeAndLadder.Gameplay {
    internal class BlockEffectManager : MonoBehaviour {
        public List<BlockEffectSource> blockEffectsList;


        internal void Evaluate() {
            foreach(BlockEffectSource blockEffect in blockEffectsList) {
                blockEffect.Activate();
            }
        }
    }
}