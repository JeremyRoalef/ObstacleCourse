using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    //Get particle system for player death and the reload wait time from Unity editor
    [SerializeField] ParticleSystem playerDeath;
    [SerializeField] float fltReloadWaitTime;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Obstacle")
        {

            Instantiate(playerDeath, transform.position, transform.rotation); //instantiate particle system

            //destroy player (Hide the player to continue using script)
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.GetComponent<Rigidbody>().useGravity = false;

            //Get the virtual camera following the player
            GameObject camera = GameObject.FindGameObjectWithTag("Camera"); //Get object in scene tagged "Camera"
            CinemachineVirtualCamera cmvc = camera.GetComponent<CinemachineVirtualCamera>(); //Get camera's CinemachineVirtualCamera component
            
            //Set the component's Follow and Look At to nothing
            cmvc.LookAt = null;
            cmvc.Follow = null;

            ReloadScene(); //Reload the scene
        }
    }

    public void ReloadScene()
    {
        StartCoroutine(WaitToReload()); //Call the coroutine to reload the scene
    }
    IEnumerator WaitToReload()
    {
        yield return new WaitForSeconds(fltReloadWaitTime); //Wait given time before returning anything
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Reload the current scene
    }
}
