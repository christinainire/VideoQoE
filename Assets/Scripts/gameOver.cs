using UnityEngine;

public class gameOver : MonoBehaviour
{
    private void OnGUI()
    {

        GUI.Label(new Rect(400, 100, 800, 100), "Congratulations! You have finished the task perfectly! Thank you!!!");

    }
}
