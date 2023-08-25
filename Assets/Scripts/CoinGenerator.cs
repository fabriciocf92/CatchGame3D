using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    void Start()
    {
        MonoBehaviour.Instantiate(Resources.Load<GameObject>(Constants.GoldCoinPrefab));
    }

}
