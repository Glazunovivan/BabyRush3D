using UnityEngine;
using UnityEngine.UI;

//Шаблон
public class ItemInShop : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private GameObject _borderLock;
    [SerializeField] private GameObject _borderUnlock;

    private SaveSystem _saveSystem;
    private IItem _item;
    private AssetItem _assetItem;

    private void Awake()
    {
        _icon.gameObject.SetActive(false);
        _borderUnlock.SetActive(false);
        _borderLock.SetActive(false);
    }

    public void Render(IItem item)
    {
        _item = item;
        _assetItem = (AssetItem)item;

        _icon.sprite = item.Icon;
        _icon.gameObject.SetActive(true);

        if (_item.IsBought)
        {
            _borderUnlock.SetActive(true);
        }
        else
        {
            _borderLock.SetActive(true);
        }
    }

    public void EquipItem()
    {
        if (_item.IsBought)
        {
            FindObjectOfType<PlayerSetting>().EquipItem(_assetItem);
            Debug.Log("Экипировали предмет");
        }
        else
        {
            Debug.Log("Предмет заблокирован");
        }
    }
}
