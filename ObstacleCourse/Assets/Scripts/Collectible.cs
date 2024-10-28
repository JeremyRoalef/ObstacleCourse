using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] float fltRotateSpeed = 1f;
    [SerializeField] GameObject wallToMove;

    void Update()
    {
        RotateObject(); //Rotate the object
    }

    void RotateObject()
    {
        transform.Rotate(0, fltRotateSpeed*Time.deltaTime, 0); //Rotate the object at given speed
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Tell the wall to move that the player collected the collectible
            wallToMove.GetComponent<WallMover>().PlayerCollectedCollectible();
            Destroy(gameObject); //Destroy this game object
        }
    }
}
