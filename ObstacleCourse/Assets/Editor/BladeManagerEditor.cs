using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//Change behavior of script from MonoBehaviour to Editor

[CustomEditor(typeof(Spinner))] //customize the editor of the spinner script
public class BladeManagerEditor : Editor
{
    //This script will allow me to create custom spinners with different blade amounts from the unity editor itself
    public override void OnInspectorGUI()
    {
        //Draw default inspector
        DrawDefaultInspector();

        //get reference to Spinner.cs
        Spinner spinner = (Spinner)target;

        //Add button to unity editor to trigger blade creation
        if (GUILayout.Button("Create Spinner"))
        {
            spinner.CreateBlades();
        }
    }
}
