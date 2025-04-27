using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CoinsSpawner : MonoBehaviour
{
    [SerializeField] private List<Coin> coins;
    [SerializeField] private bool _isRespawn = true;
    [SerializeField] private int _respawnDelay = 5;

    public event Action<Coin> Collected;

    private void OnEnable()
    {
        foreach(Coin coin in coins)
        {
            coin.Collected += OnCollected;
        }
    }

    private void OnDisable()
    {
        foreach (Coin coin in coins)
        {
            coin.Collected -= OnCollected;
        }
    }

    private void Awake()
    {
        //_pool = new ObjectPool<Coin>()
    }

    private void OnCollected(Coin coin)
    {
        Collected?.Invoke(coin);

        if (_isRespawn)
        {
            coin.Respawn(_respawnDelay);
        }
    }
}
