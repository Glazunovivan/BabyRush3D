using UnityEngine;

public class Coins : MonoBehaviour
{
    public uint AmountCoins { get; set; }

    void Start()
    {
        //на старте уровня всегда ноль
        AmountCoins = 0;
    }

    private void AddCoin()
    {
        AmountCoins++;
    }

    private void OnEnable()
    {
        //подписка
        FindObjectOfType<PlayerCollider>().coinTake += AddCoin;
    }

    private void OnDestroy()
    {
        //отписка
        FindObjectOfType<PlayerCollider>().coinTake -= AddCoin;
    }

}
