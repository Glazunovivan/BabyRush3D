using UnityEngine;

public class PlayerSetting : MonoBehaviour
{
    [SerializeField] private Transform _transformForItems;
    [SerializeField] private Transform _parent;

    private GameObject _currentEquip = null;

    public void EquipItem(ItemData item)
    {
        if (_currentEquip!=null)
        {
            Destroy(_currentEquip);
        }
        var gameObject = Instantiate(item.Model, _parent);
        //gameObject.transform.SetParent(_parent);
        gameObject.transform.localPosition = Vector3.zero;
        _currentEquip = gameObject;
    }
}
