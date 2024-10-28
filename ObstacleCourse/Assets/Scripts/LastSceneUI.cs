using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LastSceneUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText; //Get the text to display the score

    void Start()
    {
        scoreText.text = "Time taken: " + Time.time + "s"; //Display the score
    }
}
