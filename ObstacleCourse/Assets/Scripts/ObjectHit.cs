using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        //Debug.Log("Wall has been hit");
        if (other.gameObject.tag == "Player") //get the component of the object and change its color
        {
            //GetComponent<MeshRenderer>().material.color = Color.red; //Change the meshrenderer's material color to red.
            gameObject.tag = "Hit";
        }
        
    }
}
