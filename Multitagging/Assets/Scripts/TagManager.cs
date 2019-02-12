#if UNITY_EDITOR
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TagManager : EditorWindow
{
	string enumName = "CTag";
    int numTags = 3;
    bool error;

    public static string[] tags = { "Foo", "Goo", "Hoo" };

    [MenuItem( "Window/Custom/Tag Manager" )]
	public static void ShowWindow ()
	{
		GetWindow<TagManager>("Tag Manager");
	}

    protected void OnEnable()
    {
        List<string> tmp = new List<string>();
        for(int i = 0; true; ++i)
        {
            string str = EditorPrefs.GetString("CTag" + i);
            if(str == "")
                break;
            tmp.Add(str);
        }
        tags = tmp.ToArray();
        //Debug.Log("Tags recovered");
    }

    void OnGUI ()
	{
        numTags = EditorGUILayout.IntField("Tag number", numTags);

        if(tags.Length != numTags)
        {
            Array.Resize(ref tags, numTags);
        }

        for(int i = 0; i < numTags; ++i)
        {
            tags[i] = EditorGUILayout.TextField("Tag" + i, tags[i]);
        }

		enumName = EditorGUILayout.TextField("enumName", enumName);

		if (GUILayout.Button("Set Tags"))
		{
			SetTags();
		}

        if(error)
        {
            EditorGUILayout.HelpBox("One or more fields are empty.", MessageType.Error);
        }
	}

	public void SetTags()
	{
        //Make sure there are no empty fields
        for(int i = 0; i < tags.Length; ++i)
        {
            if(tags[i] == "")
            {
                error = true;
                return;
            }
        }

        error = false;

        for(int i = 0; i < tags.Length; ++i)
        {
            EditorPrefs.SetString("CTag"+i, tags[i]);
        }

        //Debug.Log("Tags saved");
    }
}
#endif