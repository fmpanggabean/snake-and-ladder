using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using SnakeAndLadder.Gameplay;
using System;

#if UNITY_EDITOR
[CustomEditor(typeof(World))]
[CanEditMultipleObjects]
public class WorldEditor : Editor
{
    private World World => (World)target;
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        if (GUILayout.Button("Add Block Up")) {
            World.CreateBlock(Vector3.forward);
            EditorUtility.SetDirty(World);
        } else if (GUILayout.Button("Add Block Right")) {
            World.CreateBlock(Vector3.right);
            EditorUtility.SetDirty(World);
        }
        else if (GUILayout.Button("Add Block Down")) {
            World.CreateBlock(Vector3.back);
            EditorUtility.SetDirty(World);
        }
        else if (GUILayout.Button("Add Block Left")) {
            World.CreateBlock(Vector3.left);
            EditorUtility.SetDirty(World);
        }
        if (GUILayout.Button("Remove Last Block")) {
            World.RemoveLast();
            EditorUtility.SetDirty(World);
        }
        if (GUILayout.Button("Remove All")) {
            World.ClearBlock();
            EditorUtility.SetDirty(World);
        }
    }
}
#endif