using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnakeAndLadder
{
    [CreateAssetMenu(fileName = "Persistent Data", menuName = "Scriptable Objects/Persistent Data")]
    public class PersistentData : ScriptableObject
    {
        public int playerQuantity;
    }
}
