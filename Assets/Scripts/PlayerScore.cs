using System;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{

    public int score;

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Coin"))
        {
            var coin = hit.gameObject.GetComponent<Coin>();
            score += coin.Value;
            coin.Spawn();
        }
    }

}
