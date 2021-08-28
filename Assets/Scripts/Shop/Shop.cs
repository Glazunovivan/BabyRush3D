using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    private uint _costForRandomUnlocked = 250;
    private ShopCategory _shopCategory;
    private SaveSystem _saveSystem;

    [SerializeField] private RewAd _adversting;
    [SerializeField] private GameObject _buttonAdvesting;

    private void Start()
    {
        _shopCategory = FindObjectOfType<ShopCategory>();
        _saveSystem = FindObjectOfType<SaveSystem>();

        _buttonAdvesting.GetComponent<Button>().onClick.AddListener(UnlockForAdversting);
    }

    public void UnlockForAdversting()
    {
        _buttonAdvesting.GetComponent<Button>().interactable = false;
        _adversting.ShowAdversting();
        RandomItem();
        _saveSystem.Save();
        _buttonAdvesting.GetComponent<Button>().interactable = true;
    }

    public void UnlockForCoins()
    {
        if (FindObjectOfType<SaveSystem>().SaveData.Coins >= _costForRandomUnlocked)
        {
            RandomItem();
            _saveSystem.SaveData.Coins -= _costForRandomUnlocked;
            _saveSystem.Save();
        }
        else
        {
            Debug.Log("Недостаточно средств");
        }
    }

    private void RandomItem()
    {
        List<int> lockedItemID = new List<int>();
        int index = 0;
        foreach (AssetItem itm in _shopCategory.CurrentItems)
        {
            if (!itm.IsBought)
            {
                lockedItemID.Add(index);
            }
            index++;
        }

        if (lockedItemID.Count > 0)
        {
            int random = UnityEngine.Random.Range(0, lockedItemID.Count);
            _shopCategory.CurrentItems[lockedItemID[random]].IsBought = true;
            _saveSystem.SaveData.NameUnlockedItems.Add(_shopCategory.CurrentItems[lockedItemID[random]].Name);
            Debug.Log("Разблокировали предмет " + _shopCategory.CurrentItems[lockedItemID[random]].Name);

            //перерисовать рамку предмета
            _shopCategory.CurrentPanel.GetComponent<PanelItems>().Render();
        }
        else
        {
            Debug.Log("Все предметы разблокированы!");
        }
    }
}
