using UnityEngine;

[CreateAssetMenu(menuName = "Items", fileName = "New item")]
public class ItemData : ScriptableObject
{
    public string Name;
    public Sprite Icon;
    [SerializeField] public bool IsBought = false;
    public GameObject Model;
}
