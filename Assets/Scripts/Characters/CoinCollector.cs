using System;
using UnityEngine;

[RequireComponent (typeof(Collider2D))]
public class CoinCollector : MonoBehaviour
{
    [SerializeField] private CoinWallet _coinWallet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            coin.Pick();
            _coinWallet.CollectCoin(coin);
        }
    }
}
