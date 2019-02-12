using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //if(collision.gameObject.CheckTag("q"))
        //if(collision.gameObject.CheckContainsTags(gameObject.GetTags()))
        if(collision.gameObject.CheckMultipleTags(gameObject.GetTags()))
        {
            Debug.Log("Objective has the provided tag.");
        }
        else
        {
            Debug.Log("No tag coincidences");
        }
    }
}
