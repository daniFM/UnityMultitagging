using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Custom/Custom Tag")]
public class CTag : MonoBehaviour
{
    [HideInInspector]
    public int numTags;
    [HideInInspector]
    public string[] tags;
    [HideInInspector]
    public int[] indices;

    public bool HasTag(string tag)
    {
        bool has = false;

        for(int i = 0; i < tags.Length; ++i)
        {
            if(tags[i] == tag)
                has = true;
        }
        return has;
    }
}
