using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float StartTime;
    private int PassedSeconds;
    private Text timer;
    public GameObject score;
    private int TotalTime = 30;

    void Start()
    {
        StartTime = Time.realtimeSinceStartup;
        timer = GetComponent<Text>();
    }

    void Update()
    {
        var NewPassedSeconds = (int)(Time.realtimeSinceStartup - StartTime);
        if (NewPassedSeconds > PassedSeconds)
        {
            PassedSeconds = NewPassedSeconds;
            timer.text = (TotalTime - PassedSeconds).ToString();
            timer.color = Color.Lerp(Color.green, Color.red, PassedSeconds/((float) TotalTime));
            if (PassedSeconds == TotalTime) 
            {
                score.SetActive(true);
                Time.timeScale = 0;
                this.enabled = false; 
            }
        }
    }
}
