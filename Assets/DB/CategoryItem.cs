using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class CategoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    private Transform _initParent;
    private Vector2 _initPosition;
    private RectTransform _rectTransform;
    public Canvas canvas;

    private ItemGroup _itemGroup;
    private Image _image;

    private bool _occupied;
    public bool Occupied
    {
        get => _occupied;
    }

    public ItemGroup ItemGroup
    {
        get => _itemGroup;
    }


    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _initParent = transform.parent;
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
        _initPosition = _rectTransform.anchoredPosition;
        _image = GetComponent<Image>();
    }

    public void Init(ItemGroup itemGroup, Sprite sprite)
    {
        _itemGroup = itemGroup;
        _image.sprite = sprite;
        _occupied = true;
        transform.SetParent(_initParent);
        _rectTransform.anchoredPosition = _initPosition;
        gameObject.SetActive(true);        

    }

    public void PlaceItem(Vector2 newAncPos)
    {
        _rectTransform.anchoredPosition = newAncPos;
    }

    public void ReturnToInitialPosition()
    {
        transform.SetParent(_initParent, true);
        transform.SetAsLastSibling();
        _canvasGroup.blocksRaycasts = true;
        _rectTransform.anchoredPosition = _initPosition;        
    }



    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(canvas.transform, true);
        transform.SetAsLastSibling();
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ReturnToInitialPosition();
    }

    private void OnDisable()
    {        
        enabled = true;
        _occupied = false;
        _canvasGroup.blocksRaycasts = true;
    }




}
