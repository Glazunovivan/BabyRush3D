using UnityEngine;

public class Coins : MonoBehaviour
{
    public uint AmountCoins { get; set; }

    void Start()
    {
        //�� ������ ������ ������ ���� �����
        AmountCoins = 0;
    }

    private void AddCoin()
    {
        AmountCoins++;
    }

    private void OnEnable()
    {
        FindObjectOfType<PlayerCollider>().coinTake += AddCoin;
    }

    private void OnDestroy()
    {
        FindObjectOfType<PlayerCollider>().coinTake -= AddCoin;
    }

}
