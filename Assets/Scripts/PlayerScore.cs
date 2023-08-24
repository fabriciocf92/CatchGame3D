using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{

    private int score;
    public Text ScoreText;
    public Text FinalScoreText;
    public Text RecordText;
    private float LastCoinTime = 0;

    private void OnEnable()
    {
        Timer.Instance.AfterFinished += WriteScore;
    }
    private void OnDisable()
    {
        Timer.Instance.AfterFinished -= WriteScore;
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Coin") && Time.timeSinceLevelLoad - LastCoinTime > 0.1)
        {
            LastCoinTime = Time.timeSinceLevelLoad;
            var coin = hit.gameObject.GetComponent<Coin>();
            score += coin.Value;
            ScoreText.text = score.ToString();
            coin.Spawn();
        }
    }

    private void WriteScore()
    {
        var record = PlayerPrefs.GetInt(Constants.Record);
        if (score > record)
        {
            PlayerPrefs.SetInt(Constants.Record, score);
            record = score;
        }
        FinalScoreText.text = score.ToString();
        RecordText.text = record.ToString();
    }

}
