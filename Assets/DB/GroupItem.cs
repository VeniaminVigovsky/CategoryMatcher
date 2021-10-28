using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class GroupItem : MonoBehaviour, IDropHandler
{
    public ItemGroup _itemGroup;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void Init(ItemGroup itemGroup, Sprite sprite)
    {
        _itemGroup = itemGroup;
        _image.sprite = sprite;
    }


    public void OnDrop(PointerEventData eventData)
    {
        CategoryItem categoryItem = eventData.pointerDrag.GetComponent<CategoryItem>();
        if (categoryItem != null)
        {
            if (categoryItem.ItemGroup == _itemGroup)
            {
                GameManager.Instance?.MakeMove(true);
                categoryItem.gameObject.SetActive(false);
            }
            else
            {
                GameManager.Instance?.MakeMove(false);
                categoryItem.ReturnToInitialPosition();
            }
        }
        
    }

}
