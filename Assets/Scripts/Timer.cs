using UnityEngine;
using UnityEngine.UI;

public class Timer : Singleton<Timer>
{
    private float StartTime;
    private int PassedSeconds;
    private Text timer;
    public GameObject score;
    private readonly int TotalTime = 30;

    public delegate void Finalizer();
    public event Finalizer AfterFinished;

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
                AfterFinished?.Invoke();
            }
        }
    }
}
