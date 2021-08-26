using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private Text _amountCoins;

    private void Start()
    {
        _amountCoins.text = FindObjectOfType<SaveSystem>().SaveData.Coins.ToString();
    }

    public void CloseShop()
    {
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("Shop");
    }
}
