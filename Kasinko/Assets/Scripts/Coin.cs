using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    
    public GameObject coin;
    private float time_range = 1.0f;
    private float remaining_time = 0.0f;
    private int numOfPrincess =0;
    private void Update()
    {
        if (Time.time>= remaining_time)
        {
            SpawnCoin();
            remaining_time = time_range + Time.time;
        }
    }
    void SpawnCoin()
    {
        Vector3 position = new Vector3(Random.Range(-2.6F, 2.6F), UnityEngine.Random.Range(-5.2F, 4.2F), 1);
        Instantiate(coin, position, transform.rotation);
    }
}
