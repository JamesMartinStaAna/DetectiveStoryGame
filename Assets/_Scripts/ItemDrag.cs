using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DetectiveGame.Player;
using UnityEngine.EventSystems;

public class ItemDrag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerDownHandler
{
    #region IDragHandler implementation

    private RectTransform rectTransform;
    private Transform initialParent;
    private Vector3 initialPosition;
    private Player player;
    private Canvas canvas;
    private Item item;
    private TargetPosition targetPosition;
    [SerializeField] private bool getOutOfParent;

    private void Awake()
    {
        targetPosition = FindObjectOfType<TargetPosition>();
        item = GetComponent<Item>();
        player = FindObjectOfType<Player>();
        rectTransform = GetComponent<RectTransform>();
        canvas = FindObjectOfType<Canvas>();
        initialParent = this.transform.parent;
        initialPosition = this.transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 camPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = camPos;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        this.transform.SetParent(this.transform.parent.parent);
        if (getOutOfParent == true)
        {
            targetPosition.FollowTarget = player.transform.position;
        }

        Cursor.visible = false;

        player.IsDraggingAnItem = true;
        item.ToggleItemReceivers(true);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ResetToInventory();
        player.IsDraggingAnItem = false;
        item.dragReleaseEvent?.Invoke(item);
        item.ToggleItemReceivers(false);
        Cursor.visible = true;
    }

    private void ResetToInventory()
    {
        this.transform.SetParent(initialParent);
        this.transform.position = initialPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        player.IsDraggingAnItem = true;
    }

    #endregion
}
