using System;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemData _itemData;
    [SerializeField] public int ID;
    
    [SerializeField] private Image _icon;
    [SerializeField] private Image _lock;
    [SerializeField] private Image _unlock;

    [SerializeField] public bool IsUnlock;

    private Shop _shop;

    private void Start()
    {
        _shop = FindObjectOfType<Shop>();


        _lock.gameObject.SetActive(false);
        _unlock.gameObject.SetActive(false);
        _icon.sprite = _itemData.Icon;

        _shop.BuyItemHandler += UpdateBorder;

        UpdateBorder();
    }

    private void UpdateBorder()
    {
        if (IsUnlock == true)
        {
            _unlock.gameObject.SetActive(true);
        }
        else
        {
            _lock.gameObject.SetActive(true);
        }
    }

    public void SelectedItem()
    {
        if (IsUnlock)
        {
            Debug.Log($"Взяли в руки {_itemData.Name}");
            FindObjectOfType<PlayerSetting>().EquipItem(_itemData);
        }
    }
}
