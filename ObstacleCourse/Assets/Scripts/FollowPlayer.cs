using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //Craete object of type CinemachineVirtualCamera
    CinemachineVirtualCamera cinemachineVirtualCamera;
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player"); //Find player in the game world
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>(); //get the camera's component
        cinemachineVirtualCamera.LookAt = player.transform; //Set the camera's look at to the player's position
        cinemachineVirtualCamera.Follow = player.transform; //Set the camera's follow to the player's position
    }
}
