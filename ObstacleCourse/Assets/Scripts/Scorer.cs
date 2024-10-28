using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    int intObjectsHit = 0; //Create variable to hold number of objects hit

    private void OnCollisionEnter(Collision other)
    {
        //If player hits an object tagged "Obstacle", increase number of objects hit by 1 and show number of objects hit
        if (other.gameObject.tag == "Obstacle")
        {
            intObjectsHit++;
            Debug.Log("Objects hit: " + intObjectsHit);
        }
    }
}
