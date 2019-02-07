using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CTag))]
[CanEditMultipleObjects]
public class CTagEditor : Editor
{
    int numTags;
    int[] selected;
    bool foldout;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        CTag ctag = (CTag)target;

        //EditorGUILayout.LabelField("Tags");
        
        foldout = EditorGUILayout.Foldout(foldout, "Tags");
        if(foldout)
        {
            EditorGUILayout.LabelField("Number of tags");
            numTags = EditorGUILayout.IntField(numTags);

            if(numTags != ctag.tags.Length)
            {
                Array.Resize(ref ctag.tags, numTags);
                Array.Resize(ref ctag.indices, numTags);
            }

            for(int i = 0; i < numTags; ++i)
            {
                ctag.indices[i] = EditorGUILayout.Popup(ctag.indices[i], TagManager.tags);
                ctag.tags[i] = TagManager.tags[ctag.indices[i]];
            }
        }
    }
}
