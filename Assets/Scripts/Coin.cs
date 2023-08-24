using System;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    public int Value;
    public bool Collided = false;

    private void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        this.transform.position = ScenaryArea.Instance.getRandomPoint(this.GetComponent<Collider>());
    }

    private void OnCollisionEnter(Collision collision)
    {
        Collided = true;
    }

}
