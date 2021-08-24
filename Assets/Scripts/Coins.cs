using UnityEngine;

public class Coins : MonoBehaviour
{
    public uint AmountCoins { get; set; }

    private SaveSystem _saveSystem;

    void Start()
    {
        //на старте уровня всегда ноль
        AmountCoins = 0;

        _saveSystem = FindObjectOfType<SaveSystem>();
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
    private void OnDisable()
    {
        //отписка
        FindObjectOfType<PlayerCollider>().coinTake -= AddCoin;
        Debug.Log("Стираем объект Coins");
        //сохранение монет в файл, чтобы использовать их в магазине
        _saveSystem.SaveData.Coins += AmountCoins;
        _saveSystem.Save();
    }
}
