using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText; //Get time text

    void Start()
    {
        timeText.text = Time.time.ToString() + "s"; //Initialize time text to initial time
    }

    void Update()
    {
        UpdateTime();
    }

    void UpdateTime()
    {
        timeText.text = string.Format("{0:F1}", Time.time) + "s"; //Update time text by elapsed time
    }
}
