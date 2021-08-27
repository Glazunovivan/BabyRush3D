using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    //список всех предметов
    public List<Item> Items;
    
    private SaveData _saveData;

    public delegate void OnBuyItem();
    public event OnBuyItem BuyItemHandler;

    private void Awake()
    {
        _saveData = FindObjectOfType<SaveSystem>().SaveData;

        //изначально обнуляем их все
        for (int i = 0; i < Items.Count; i++)
        {
            Items[i].IsUnlock = false;
        }

        //foreach (ItemData item in _saveData.PurchasedItems)
        //{
        //    foreach (ItemData itemAll in Items)
        //    {
        //        if (item.name == itemAll.name)
        //        {
        //            Items[item.]
        //        }
        //    }
        //}

        foreach (int idTempItem in _saveData.IDPurchasedItems)
        {
            Items[idTempItem].IsUnlock = true;
        }
    }

    public void SelectedItem(ItemData item)
    {
        if (item.IsBought)
        {
            //кастомизируем игрока
        }
    }

    public void UnlockRandomForCoins()
    {
        if (FindObjectOfType<SaveSystem>().SaveData.Coins >= 250)
        {
            List<int> lockedItemIndex = new List<int>();

            int index = 0;
            foreach (Item itemLock in Items)
            {
                if (itemLock.IsUnlock == false)
                {
                    lockedItemIndex.Add(index);
                }
                index++;
            }
            if (lockedItemIndex.Count > 0)
            {
                int rand = Random.Range(0, lockedItemIndex.Count);

                Items[lockedItemIndex[rand]].IsUnlock = true;

                //добавить в сохранение
                _saveData.IDPurchasedItems.Add(Items[lockedItemIndex[rand]].ID);

                _saveData.Coins -= 250;
                Debug.Log("Что-то купили");
            }            
            Updating();
        }
        else
        {
            Debug.Log("Недостаточно средств");
        }
    }


    private void Updating()
    {
        BuyItemHandler?.Invoke();
    }


    public void UnlockRandomForAdversting()
    {
        Debug.Log("Реклама");
    }

}
