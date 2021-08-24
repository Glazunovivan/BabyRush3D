using UnityEngine;
using UnityEngine.UI;
public class ShopUI : MonoBehaviour
{

    [SerializeField] private Text _amountCoins;

    public void CloseShop()
    {
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("Shop");
    }
}
