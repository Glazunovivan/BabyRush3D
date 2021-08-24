using UnityEngine;
using UnityEngine.UI;
public class ShopUI : MonoBehaviour
{
    [SerializeField] private Text _amountCoins;

    private SaveSystem _saveSystem;
    
    private void Start()
    {
        _saveSystem = FindObjectOfType<SaveSystem>();
        _amountCoins.text = _saveSystem.SaveData.Coins.ToString();
    
    }


    public void CloseShop()
    {
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("Shop");
    }
}
