using UnityEngine;
using System.Collections.Generic;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public float spawnInterval = 7f;
    private bool isSpawning;
    private List<GameObject> spawnedCoins = new List<GameObject>();

    void Start()
    {
    }

    public void StartSpawning()
    {
        if (isSpawning)
            return;

        InvokeRepeating("SpawnCoin", 3f, spawnInterval);
        isSpawning = true;
    }

    public void StopSpawning()
    {
        CancelInvoke("SpawnCoin");
        isSpawning = false;
    }
    void SpawnCoin()
    {
        float randomX = Random.Range(-8f, 8f);

        Vector2 spawnPosition = new Vector2(randomX, transform.position.y);

        GameObject coin = Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
        spawnedCoins.Add(coin);
    }

    public void DestroyAllCoins()
    {
        foreach (GameObject coin in spawnedCoins)
        {
            if (coin != null)
            {
                Destroy(coin);
            }
        }

        spawnedCoins.Clear();
    }

    
}