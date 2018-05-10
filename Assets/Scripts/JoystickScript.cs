using UnityEngine;
using System;
using System.Collections;
using System.IO;
using UnityEngine.SceneManagement;



public class JoystickScript : MonoBehaviour
{
    private IEnumerator coroutine;
    public String file_name;
    public String scene_name;
    public float T;
    StreamWriter fileWriter = null;

    // Perform when the aplication is launched
    void Start()
    {
        coroutine = WaitAndPrint(0.03333333F);
        StartCoroutine(coroutine);
    }

    // When the scene is loaded 
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.activeSceneChanged += closeFile;
    }

    // Close the File
    void closeFile(Scene prev, Scene curr)
    {
        // Close the file if its open
        try
        {
            // Close the file stream
            fileWriter.Close();
        }
        // Avoid debug error if the first scene is loaded
        catch
        {
            // Ignore
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        scene_name = scene.name;

    }



    IEnumerator WaitAndPrint(float waitTime)
    {
        // Create the file name
        file_name = @"E:/unityLog/" + scene_name + "_" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Month.ToString()
            + "_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Hour.ToString()
            + "h_" + DateTime.Now.Minute.ToString() + "min_" + DateTime.Now.Second.ToString()
            + "s" + ".txt";

        fileWriter = File.CreateText(file_name);

        // Loop the Timer
        while (true)
        {
            // Get the Input
            Vector3 inputDirection = Vector3.zero;
            inputDirection.x = Input.GetAxis("R_Horizontal");

            // Get the Time
            T += Time.fixedDeltaTime;

            // Write the data to the file
            //WriteToLogFile(inputDirection.x + ", " + T);
            fileWriter.WriteLine(inputDirection.x + ", " + T);

            // Display in Unity (For Debugging)
            //UnityEngine.Debug.Log(inputDirection.x + ", " +T);

            // Wait 0.03333333 Seconds
            yield return new WaitForSeconds(waitTime);
        }
    }

    // Ensure all files are closed to preserve data
    void OnApplicationQuit()
    {
        // Close the open file stream
        fileWriter.Close();
    }
}
