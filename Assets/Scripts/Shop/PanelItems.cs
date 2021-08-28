using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelItems : MonoBehaviour
{
    [Tooltip("Предметы которые отображаем на этой панели")] 
    [SerializeField] private List<AssetItem> _items;
    public List<AssetItem> GetItems
    {
        get
        {
            return _items;
        }
    }
    
    [SerializeField] private ItemInShop _itemInShopPrefab;
    [SerializeField] private Transform _transform;

    private void Start()
    {
        InitItemValueIsBought();
        Render();
    }

    private void OnEnable()
    {
        Render();
    }

    private void InitItemValueIsBought()
    {
        SaveSystem saveSystem = FindObjectOfType<SaveSystem>();
        foreach (string name in saveSystem.SaveData.NameUnlockedItems)
        {
            foreach (AssetItem assetItem in _items)
            {
                if (assetItem.Name == name)
                {
                    assetItem.IsBought = true;
                    break;
                }
            }
        }
    }

    public void Render()
    {
        FindObjectOfType<ShopCategory>().CurrentItems = _items;
        FindObjectOfType<ShopCategory>().CurrentPanel = this.gameObject;

        foreach (Transform child in _transform)
        {
            Destroy(child.gameObject);
        }

        _items.ForEach(item =>
        {
            var cell = Instantiate(_itemInShopPrefab, _transform);
            cell.Render(item);
        });
    }
}
