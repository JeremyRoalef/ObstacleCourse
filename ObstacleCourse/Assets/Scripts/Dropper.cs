using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    [SerializeField] float fltDropWaitTime;
    private new MeshRenderer renderer; //Create MeshRenderer object
    private Rigidbody rigidBody; //Create Rigidbody object

    void Start()
    {
        renderer = GetComponent<MeshRenderer>(); //Get the MeshRenderer component attached to this object
        renderer.enabled = false; //Hide the object's renderer
        rigidBody = GetComponent<Rigidbody>(); //Get the Rigidbody component attached to this object
        rigidBody.useGravity = false; //Turn off Newton's Law
    }

    void Update()
    {
        //If the object has time to wait, wait out the time
        if (Time.time >= fltDropWaitTime)
        {
            //Debug.Log("Time has been elapsed");
            //enable object's components
            renderer.enabled = true;
            rigidBody.useGravity = true;
        }
    }
}
