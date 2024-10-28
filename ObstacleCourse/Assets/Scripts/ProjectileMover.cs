using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMover : MonoBehaviour
{
    [SerializeField] float fltMoveSpeed = 2.0f;

    void Update()
    {
        Vector3 moveAmount = new Vector3(0f,0f,fltMoveSpeed*Time.deltaTime);
        //transform.Translate does not move the object in the general world's x,y, and z axes but
        //relative to the object's own x, y, and z axes.
        transform.Translate(moveAmount);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject); //Destroy the object
    }
}
