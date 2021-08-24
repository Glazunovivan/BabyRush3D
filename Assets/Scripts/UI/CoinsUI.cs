using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsUI : MonoBehaviour
{
    [SerializeField] private Text _amountText;
    private Coins _coinsComponent;
    private void Awake()
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
