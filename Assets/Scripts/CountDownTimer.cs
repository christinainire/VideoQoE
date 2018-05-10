using UnityEngine;

public class CountDownTimer : MonoBehaviour
{
    float timerRemaining = 10;

    // Use this for initialization
    void Start() {}

    // Update is called once per frame
    void Update()
    {
        timerRemaining -= Time.deltaTime;
    }
    private void OnGUI()
    {
        if (timerRemaining > 0)
        {
            GUI.Label(new Rect(400, 100, 800, 100), 
                "Please place your hands on the joystick and focus on the content being presented prior to play");
            GUI.Label(new Rect(400, 150, 800, 100), 
                "You can press the spacebar on keyboard to pause when you need.");
            GUI.Label(new Rect(400, 200, 200, 100), 
                "Time Remaing :" + (int)timerRemaining);
        }
        else
        {
            GUI.Label(new Rect(400, 200, 100, 100), "Video Start !");
        }
    }
}

