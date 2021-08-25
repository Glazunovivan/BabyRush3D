using UnityEngine;
using UnityEngine.UI;

public class CoinsUI : MonoBehaviour
{
    [SerializeField] private Text _amountText;
    [SerializeField] private Coins _coinsComponent;

    private void Start()
    {
        FindObjectOfType<PlayerCollider>().coinTake += UpdateUI;
        _coinsComponent = FindObjectOfType<Coins>();
        _amountText.text = _coinsComponent.AmountCoins.ToString();
    }

    private void UpdateUI()
    {
        _amountText.text = _coinsComponent.AmountCoins.ToString();
    }
}
