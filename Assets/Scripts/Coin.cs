using UnityEngine;

public class Coin : MonoBehaviour
{
    public int Value;

    private void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        this.transform.position = ScenaryArea.Instance.getRandomPoint(this.GetComponent<Collider>());
        this.gameObject.SetActive(true);
    }

}
