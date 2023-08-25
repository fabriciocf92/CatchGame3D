using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    public GameObject paused;

    public void StartSingleplayer()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main");
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        paused.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        paused.SetActive(false);
    }

}
