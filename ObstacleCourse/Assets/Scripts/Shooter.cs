using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    GameObject player; //Store player object in variable
    [SerializeField] GameObject projectile; //Get projectile object

    bool boolLookAtPlayer = false;
    bool boolWaitToShoot = false;
    [SerializeField] float sfFltShootDelay;

    float fltShootDelay;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); //Find player in the scene
        fltShootDelay = sfFltShootDelay; //Initialize shoot delay value
    }

    void Update()
    {
        //If the player entered the target radius, look at and shoot the player
        if (boolLookAtPlayer)
        {
            LookAtPlayer();
            ShootPlayer();
        }
    }

    //If the player enters the target radius, look at the player
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            boolLookAtPlayer = true;
        }
    }

    //If the player exits the target radius, stop looking at player
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            boolLookAtPlayer = false;
        }
    }

    void LookAtPlayer()
    {
        transform.LookAt(player.transform.position); //Rotates the object to look at the target position
    }

    void ShootPlayer()
    {
        //If you're not waiting to shoot (Shoot delay), shoot
        if (!boolWaitToShoot)
        {
            Vector3 projectileSpawnPosition = transform.position + (transform.forward * 1.2f); //Set spawn pos
            Instantiate(projectile, projectileSpawnPosition, transform.rotation); //Create projectile
            boolWaitToShoot = true; //Wait to shoot again
        }
        //Otherwise, wait out the shoot delay
        else
        {
            fltShootDelay -= Time.deltaTime;
            //If shoot delay is over, reset its value & allow ability to shoot again
            if (fltShootDelay <= 0.1f)
            {
                fltShootDelay = sfFltShootDelay;
                boolWaitToShoot = false;
            }
        }
    }
}
