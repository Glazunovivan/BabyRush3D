using UnityEngine;

public enum TypeItem
{
    Item,
    Clothes
}

public interface IItem
{
    public Sprite Icon { get; }
    public string Name { get; }
    public TypeItem TypeItem { get; }
    public bool IsBought { get; set; }
    public GameObject Model { get; }

    public void Equip();
}
