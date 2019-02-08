using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CTag))]
//[CanEditMultipleObjects]  --> Para que funcione hay que implementar el multieditado
public class CTagEditor : Editor
{
    //int numTags;
    bool foldout = true;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        CTag ctag = (CTag)target;

        //EditorGUILayout.LabelField("Tags");
        
        foldout = EditorGUILayout.Foldout(foldout, "Tags");
        if(foldout)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Number of tags");
            ctag.numTags = EditorGUILayout.IntField(ctag.numTags);
            EditorGUILayout.EndHorizontal();

            //EditorUtility.SetDirty(target);

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

        Undo.RecordObject(ctag,"Update CTags");
    }
}
