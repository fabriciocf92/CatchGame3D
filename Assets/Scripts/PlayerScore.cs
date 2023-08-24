using UnityEngine;

public class PlayerScore : MonoBehaviour
{

    public int score;

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Coin"))
        {
            score += hit.gameObject.GetComponent<Coin>().Value;
            hit.gameObject.SetActive(false);
        }
    }

}
