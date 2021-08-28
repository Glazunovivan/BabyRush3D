using System.Collections.Generic;
using UnityEngine;

public class ShopCategory : MonoBehaviour
{
    public List<AssetItem> CurrentItems;
    public GameObject CurrentPanel;

    [SerializeField] private List<GameObject> _panelCategory;
    [SerializeField] private int _currentCategory;

    private void Start()
    {
        _currentCategory = 0;
        
        foreach (GameObject go in _panelCategory)
        {
            go.SetActive(false);
        }
        RenderCategory(_currentCategory);
    }

    public void LeftArrow()
    {
        if (_currentCategory > 0)
        {
            _currentCategory--;
            RenderCategory(_currentCategory);
        }
    }
    public void RightArrow()
    {
        if (_currentCategory + 1 < _panelCategory.Count)
        {
            _currentCategory++;
            RenderCategory(_currentCategory);
        }
    }

    private void RenderCategory(int category)
    {
        foreach (GameObject go in _panelCategory)
        {
            go.SetActive(false);
        }
        _panelCategory[category].SetActive(true);
        
    }

}
