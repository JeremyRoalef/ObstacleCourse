using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spinner : MonoBehaviour
{

    //Create serialized field attributes for spinner properties
    [SerializeField] float fltRotateSpeed;
    [SerializeField] float fltSpinDelay;
    [SerializeField] int intNumberOfBlades;
    [SerializeField] GameObject bladePrefab;
    [SerializeField] int intSpinDirection;
    [SerializeField] float fltInitialWaitTime;

    //create boolean for when object is rotating
    bool boolIsRotating = false;

    void Update()
    {
        //If there is an initial wait time, wait out the time
        if (fltInitialWaitTime > 0.01f)
        {
            fltInitialWaitTime -=Time.deltaTime; //Reduce the time to wait by the elapsed time
            return; //Do not run any more in the Update method
        }
        //If the object is not rotating, rotate object after the delay
        if (!boolIsRotating)
        {
            StartCoroutine(RotateObject());
        }
    }

    //Create coroutine to cause obejct to rotate
    IEnumerator RotateObject()
    {
        int intRotateAmount = 180 / intNumberOfBlades; //Get degree amount that the object needs to rotate based on the number of blades

        boolIsRotating = true; //Object is now rotating

        //Get current rotation & calculate the target rotation
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = startRotation * Quaternion.Euler(0, intRotateAmount * intSpinDirection, 0);

        //While there is an angle difference between the initial rotation and end rotation, rotate the object towards the end rotation
        while (Quaternion.Angle(transform.rotation, endRotation) > 0.01f) //calculates the angle between two rotations
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, endRotation, fltRotateSpeed * Time.deltaTime); //Rotate object towards end rotation at given speed
            yield return new WaitForSeconds(0); // Wait no time
        }

        transform.rotation = endRotation; //Lock rotation to the end rotation to prevent calculation errors
        yield return new WaitForSeconds(fltSpinDelay); //Delay the next rotation by the given spin delay
        boolIsRotating = false; //Object is no longer rotating
    }

    //Create public method for use by bladeManagerEditor script
    public void CreateBlades()
    {
        //Loop through all the children in the parent object and immediately destroy them
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            //Destroy the child at index i
            DestroyImmediate(transform.GetChild(i).gameObject); //DestroyImmediate used when using unity editor
        }

        //Rotation of each blade is dependent on 180 / the number of blade
        float fltBladeRotationIncrement = 180f / intNumberOfBlades;

        //Add new blades
        for (int i = 0; i < intNumberOfBlades; i++)
        {
            Quaternion bladeRoation = Quaternion.Euler(0,fltBladeRotationIncrement*i,0);

            GameObject newBlade = Instantiate(bladePrefab, transform.position, bladeRoation);

            //Give blade object a name
            newBlade.name = "Blade(" + (i+1) + ")";

            //Set its parent object to object the script is on
            newBlade.transform.SetParent(transform);
        }
    }
}
