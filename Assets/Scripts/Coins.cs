using UnityEngine;

public class Coins : MonoBehaviour
{
    public uint AmountCoins { get; set; }

    private SaveSystem _saveSystem;

    void Start()
    {
        //�� ������ ������ ������ ����
        AmountCoins = 0;

        _saveSystem = FindObjectOfType<SaveSystem>();
    }

    private void AddCoin()
    {
        AmountCoins++;
    }

    private void OnEnable()
    {
        //��������
        FindObjectOfType<PlayerCollider>().coinTake += AddCoin;
    }
    private void OnDisable()
    {
        //�������
        FindObjectOfType<PlayerCollider>().coinTake -= AddCoin;
        Debug.Log("������� ������ Coins");
        //���������� ����� � ����, ����� ������������ �� � ��������
        _saveSystem.SaveData.Coins += AmountCoins;
        _saveSystem.Save();
    }
}
