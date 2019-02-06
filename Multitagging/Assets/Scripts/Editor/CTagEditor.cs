using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CTag))]
[CanEditMultipleObjects]
public class CTagEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        CTag ctag = (CTag)target;

        EditorGUILayout.Popup(0, TagManager.tags);
    }
}
