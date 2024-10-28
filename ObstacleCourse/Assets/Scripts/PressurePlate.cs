using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] GameObject doorTrigger;
    static GameObject wallToMove;

    new MeshRenderer renderer;

    bool boolIsActive = false;
    static int INTNUMOFPLATES;
    static int INTNUMOFACTIVEPLATES = 0;
    List<GameObject> objectsOnPlate = new List<GameObject> { }; //Store all objects on the plate
    static Vector3 wallPos;
    static Vector3 wallTargetPos;

    void Start()
    {
        wallToMove = GameObject.FindGameObjectWithTag("WallToMove");
        wallPos = wallToMove.transform.position;
        wallTargetPos = wallPos - new Vector3(0,-2,0);
        InitializeObject();
    }

    void Update()
    {
        if (INTNUMOFACTIVEPLATES == INTNUMOFPLATES)
        {
            if (wallPos == wallTargetPos) { return; }
            Vector3 moveAmount = wallTargetPos/10;
            MoveWallToPosition(moveAmount);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Box")
        {
            objectsOnPlate.Add(other.gameObject);
            SetActive();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        StayActive();
    }

    private void OnTriggerExit(Collider other)
    {
        objectsOnPlate.Remove(other.gameObject);

        if (objectsOnPlate.Count == 0)
        {
            SetInactive();
        }
    }

    private void SetInactive()
    {
        boolIsActive = false;
        renderer.material.color = Color.red;
        doorTrigger.GetComponent<MeshRenderer>().material.color = Color.red;
        INTNUMOFACTIVEPLATES--;
    }

    private void SetActive()
    {
        if (boolIsActive) {return;}

        boolIsActive = true;
        renderer.material.color = Color.green;
        doorTrigger.GetComponent<MeshRenderer>().material.color = Color.green;
        INTNUMOFACTIVEPLATES++;
        Debug.Log(INTNUMOFACTIVEPLATES);
    }  

    void StayActive()
    {
        boolIsActive = true;
        renderer.material.color = Color.green;
        doorTrigger.GetComponent<MeshRenderer>().material.color = Color.green;
    }
    
    private void InitializeObject()
    {
        INTNUMOFPLATES = GameObject.FindGameObjectsWithTag("PressurePlate").Length;
        renderer = GetComponent<MeshRenderer>();
        renderer.material.color = Color.red;
        doorTrigger.GetComponent<MeshRenderer>().material.color = Color.red;
        Debug.Log(INTNUMOFPLATES);
    }

    void MoveWallToPosition(Vector3 moveAmount)
    {
        wallToMove.transform.Translate(-wallToMove.transform.up * Time.deltaTime);
    }
}
