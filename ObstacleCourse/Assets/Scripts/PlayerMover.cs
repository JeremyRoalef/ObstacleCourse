using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] float fltMoveSpeed; //Get the speed that the player will move at
    [SerializeField] float fltRotationSpeed; //Get the rotation speed the player will rotate at


    void Update()
    {
        MovePlayer(); //Move the player
        RotatePlayer(); //Rotate the player
    }

    void MovePlayer()
    {
        float fltZValue = Input.GetAxis("Vertical") * Time.deltaTime * fltMoveSpeed; //'Time.deltaTime' removes fps requirements for movement in game
        transform.Translate(0, 0, fltZValue); //Translate the player forward
    }
    void RotatePlayer()
    {
        Quaternion startRotation = transform.rotation; //Create a rotation vector set to the player's current rotation
        Quaternion endRotation = transform.rotation * Quaternion.Euler(0, Input.GetAxis("Horizontal") * Time.deltaTime * fltRotationSpeed, 0); //Set the target rotation amount
        transform.rotation = Quaternion.RotateTowards(startRotation, endRotation, 10f); //Rotate the player towards the end rotation
    }
    private void OnTriggerEnter(Collider other)
    {
        //If player reaches the end location, load the next scene
        if (other.gameObject.tag == "EndLocation")
        {
            LoadNextScene();
        }
    }
    private void LoadNextScene()
    {
        int intNextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1; //Store the index of the next scene in build
        SceneManager.LoadScene(intNextSceneIndex); //Load the next scene in build
    }
}
