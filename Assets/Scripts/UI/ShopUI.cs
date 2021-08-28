using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private Text _amountCoins;
    [SerializeField] private ItemInShop _prefabItemInShop;

    private void Start()
    {
        _amountCoins.text = FindObjectOfType<SaveSystem>().SaveData.Coins.ToString();
    }

    public void CloseShop()
    {
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("Shop");
    }
}
