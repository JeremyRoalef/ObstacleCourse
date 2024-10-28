using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    //serialize fields for duration of move, speed, time to wait, and initial delay
    [SerializeField] float fltMoveTime;
    [SerializeField] float fltMoveSpeed;
    [SerializeField] float fltTimeToWait;
    [SerializeField] float fltInitialDelay;

    //Create placeholder variables to store values of time variables
    float fltResetMoveTime;
    float fltResetTimeToWait;

    private void Start()
    {
        //initialize placeholder variable values
        fltResetMoveTime = fltMoveTime;
        fltResetTimeToWait = fltTimeToWait;
    }
    private void Update()
    {
        //Wait for the initial delay before moving
        if (fltInitialDelay > .01f)
        {
            fltInitialDelay -= Time.deltaTime; //Reduce the initial delay by elapsed time
            return; //Do not run any more in Update method
        }


        //If not waitting to move (Time to wait = 0), move the object
        if (fltResetTimeToWait < 0.01f)
        {
            MoveObject();
        }
        //Otherwise, reduce the time to wait by the change in time
        else
        {
            fltResetTimeToWait -= Time.deltaTime;
        }
    }

    void MoveObject()
    {
        //if move time is not equal to 0, move the object at given speed
        if (fltResetMoveTime > 0.01f)
        {
            transform.Translate(fltMoveSpeed * Time.deltaTime, 0, 0); //Move object in x-direction
            fltResetMoveTime -= Time.deltaTime; //decrease move time by the change in time
        }
        //Otherwise, reverse move speed, reset move time and time to wait
        else
        {
            fltMoveSpeed *= -1;
            fltResetTimeToWait = fltTimeToWait;
            fltResetMoveTime = fltMoveTime;
        }
    }
}
