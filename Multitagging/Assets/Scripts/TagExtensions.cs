using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GameObject extensions for the CTag class
/// </summary>
public static class TagExtensions
{
    /// <summary>
    /// Returns the Custom Tags of the GameObject.
    /// </summary>
    /// <param name="go"></param>
    /// <returns>Returns null if there is no CTag attached to the GameObject.</returns>
    public static string[] GetTags(this GameObject go)
    {
        CTag ctag = go.GetComponent<CTag>();
        if(ctag != null)
        {
            return ctag.tags;
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// Checks if the GameObject has the provided tag.
    /// </summary>
    /// <param name="go"></param>
    /// <param name="tag">Tag to check.</param>
    /// <returns></returns>
    public static bool CheckTag(this GameObject go, string tag)
    {
        CTag ctag = go.GetComponent<CTag>();
        if(ctag != null)
        {
            //ctag = go.AddComponent<CTag>();
            bool has = false;

            for(int i = 0; i < ctag.tags.Length; ++i)
            {
                if(ctag.tags[i] == tag)
                    has = true;
            }
            return has;
        }
        return false;
    }

    /// <summary>
    /// Returns true if the current object has at least one of the provided tags.
    /// </summary>
    /// <param name="go"></param>
    /// <param name="tags">Tags to check.</param>
    /// <returns></returns>
    public static bool CheckMultipleTags(this GameObject go, string[] tags)
    {
        CTag ctag = go.GetComponent<CTag>();
        if(ctag != null)
        {
            for(int i = 0; i < tags.Length; ++i)
            {
                for(int j = 0; j < ctag.tags.Length; ++j)
                {
                    if(tags[i] == ctag.tags[j])
                        return true;
                }
            }
        }
        return false;
    }

    /// <summary>
    /// Returns true if the current object has all of the provided tags.
    /// </summary>
    /// <param name="go"></param>
    /// <param name="tags">Tags to check.</param>
    /// <returns></returns>
    public static bool CheckContainsTags(this GameObject go, string[] tags)
    {
        CTag ctag = go.GetComponent<CTag>();
        if(ctag != null)
        {
            for(int i = 0; i < tags.Length; ++i)
            {
                bool found = false;
                for(int j = 0; j < ctag.tags.Length; ++j)
                {
                    if(tags[i] == ctag.tags[j])
                        found = true;
                }
                if(!found)
                    return false;
            }
            return true;
        }
        return false;
    }
}
