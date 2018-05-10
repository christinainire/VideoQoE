using UnityEngine;

public class setFPS : MonoBehaviour
{
    public int target = 30;

    // Use this for initialization
    void Start()
    {
        QualitySettings.vSyncCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != Application.targetFrameRate)
        {
            Application.targetFrameRate = target;
        }
    }
}

