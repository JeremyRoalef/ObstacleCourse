using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMover : MonoBehaviour
{
    bool boolCanPass = false;
    int intNumOfCollectibles = 0;

    void Start()
    {
        //get the number of collectibles in the scene
        intNumOfCollectibles = GameObject.FindGameObjectsWithTag("Collectible").Length;
        Debug.Log("Number of collectibles: " + intNumOfCollectibles);
    }

    void Update()
    {
        if (boolCanPass)
        {
            transform.Translate(0,-1*Time.deltaTime,0); //Move wall out of the way
        }
    }

    //Create a public method to tell script when a collectible has been collected
    public void PlayerCollectedCollectible()
    {
        intNumOfCollectibles--;
        if (intNumOfCollectibles == 0)
        {
            boolCanPass = true; //There are no more collectibles
        }
    }
}
