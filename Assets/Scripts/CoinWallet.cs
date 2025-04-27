using UnityEngine;

public class CoinWallet : MonoBehaviour
{
    private int _amount = 0;

    private void Start()
    {
        ShowInfo();
    }

    public void CollectCoin(Coin coin)
    {
        _amount += coin.Value;
        coin.Hide();
        ShowInfo();
    }

    private void ShowInfo()
    {
        Debug.Log($"Coins: {_amount}");
    }

}
