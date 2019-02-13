/* * * * * * * * * * * * * * * * * * * * * * * * *\
 *                                               *
 * Copyright © 2019+ Daniel Fernández Marqués    *
 *                                               *
 * Distributed under the MIT license             *
 * See LICENSE file                              *
 *                                               *
 * contact@danifm.com                            *
 *                                               *
\* * * * * * * * * * * * * * * * * * * * * * * * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Data class of the Custom Tag
/// </summary>
[AddComponentMenu("Custom/Custom Tag")]
public class CTag : MonoBehaviour
{
    [HideInInspector]
    public int numTags;
    [HideInInspector]
    public string[] tags;
    [HideInInspector]
    public int[] indices;

    public CTag()
    {
        numTags = 0;
        tags = new string[0];
        indices = new int[0];
    }
}
