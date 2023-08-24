using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{

    private int Score;
    public Text ScoreText;
    private float LastCoinTime = 0;

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Coin") && Time.timeSinceLevelLoad - LastCoinTime > 0.1)
        {
            LastCoinTime = Time.timeSinceLevelLoad;
            var coin = hit.gameObject.GetComponent<Coin>();
            Score += coin.Value;
            ScoreText.text = Score.ToString();
            coin.Spawn();
        }
    }

}
