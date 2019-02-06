 #if UNITY_EDITOR
 using UnityEngine;
 using UnityEditor;
 using System.IO;

public class TagManager : EditorWindow
{
	string enumName = "CTag";
	string[] tags = { "Foo", "Goo", "Hoo" };
    int numTags = 3;

	[MenuItem( "Window/Custom/Tag Manager" )]
	public static void ShowWindow ()
	{
		GetWindow<TagManager>("Tag Manager");
	}

	void OnGUI ()
	{
        //GUILayout.Label("Tag Manager", EditorStyles.boldLabel);

        numTags = EditorGUILayout.IntField("Tag number", numTags);

        string [] tmp_tags = new string[numTags];

        for(int i = 0; i < numTags; ++i)
        {
            tmp_tags[i] = tags[i];
        }

        // continue here

        for(int i = 0; i < numTags; ++i)
        {
            EditorGUILayout.TextField("Tag" + i, tags[i]);
        }

		enumName = EditorGUILayout.TextField("enumName", enumName);

		if (GUILayout.Button("Set Tags"))
		{
			Go();
		}
	}

	public static void Go()
	{
		/*
		string filePathAndName = "Assets/Scripts/Tags/" + enumName + ".cs";
		//The folder Scripts/Tags/ is expected to exist

		using ( StreamWriter streamWriter = new StreamWriter( filePathAndName ) )
		{
			streamWriter.WriteLine( "public enum " + enumName );
			streamWriter.WriteLine( "{" );
			for( int i = 0; i < enumEntries.Length; i++ )
			{
				streamWriter.WriteLine( "\t" + enumEntries[i] + "," );
			}
			streamWriter.WriteLine( "}" );
		}
		AssetDatabase.Refresh();
		*/
	}
}
#endif