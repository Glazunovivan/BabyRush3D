using UnityEngine;

public class PlayerSetting : MonoBehaviour
{
    [SerializeField] private Transform _transformForItems;
    [SerializeField] private Transform _transformForClothesTop;

    public Transform GetTransformForClothesTop
    {
        get
        {
            return _transformForClothesTop;
        }
    }
    public Transform GetTransformForItems
    {
        get
        {
            return _transformForItems;
        }
    }

    private GameObject _currentEquip = null;
    private GameObject _currentClothes = null;

    public void EquipItem(AssetItem assetItem)
    {
        switch (assetItem.TypeItem)
        {
            case TypeItem.Clothes:
                if (_currentClothes != null)
                {
                    Destroy(_currentEquip);
                }
                _currentClothes = Instantiate(assetItem.Model, _transformForClothesTop);
                _currentClothes.transform.localPosition = Vector3.zero;
                break;

            case TypeItem.Item:
                if (_currentEquip != null)
                {
                    Destroy(_currentEquip);
                }
                _currentEquip = Instantiate(assetItem.Model, _transformForItems);
                _currentEquip.transform.localPosition = Vector3.zero;
                break;
        }
    }
}
