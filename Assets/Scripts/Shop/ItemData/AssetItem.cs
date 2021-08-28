using UnityEngine;

public class AssetItem : ScriptableObject, IItem
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _name;
    [SerializeField] private GameObject _model;
    [SerializeField] private TypeItem _typeItem;
    [SerializeField] private bool IsBoughtField;

    public Sprite Icon => _icon;
    public string Name => _name;
    public TypeItem TypeItem => _typeItem;
    public GameObject Model => _model;

    public bool IsBought { get { return IsBoughtField; } set { IsBoughtField = value; } }


    public virtual void Equip()
    {
        FindObjectOfType<PlayerSetting>().EquipItem(this);
    }
}