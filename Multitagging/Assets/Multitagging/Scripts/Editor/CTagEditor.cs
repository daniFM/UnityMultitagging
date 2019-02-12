using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// Custom editor for the CTag class.
/// It shows the string arrays as if they were enums.
/// </summary>
[CustomEditor(typeof(CTag))]
//[CanEditMultipleObjects]  //--> Needs multiediting to be implemented for it to really work.
public class CTagEditor : Editor
{
    bool foldout = true;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        CTag ctag = (CTag)target;
        
        foldout = EditorGUILayout.Foldout(foldout, "Tags");
        if(foldout)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Number of tags");
            ctag.numTags = EditorGUILayout.IntField(ctag.numTags);
            EditorGUILayout.EndHorizontal();

            int numTags = ctag.numTags;

            if(numTags != ctag.tags.Length)
            {
                Array.Resize(ref ctag.tags, numTags);
                Array.Resize(ref ctag.indices, numTags);
            }

            for(int i = 0; i < numTags; ++i)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Tag" + i);
                ctag.indices[i] = EditorGUILayout.Popup(ctag.indices[i], TagManager.tags);
                ctag.tags[i] = TagManager.tags[ctag.indices[i]];
                EditorGUILayout.EndHorizontal();
            }
        }

        // Makes sure al changes are saved
        Undo.RecordObject(ctag,"Update CTags");
    }
}
