using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragObject : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler 
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector3 startPosition;


  
    private bool isDragging;
    //Highlights of objects
    public string ObjectHighlightName;
    private GameObject objectHighlight;
    private SpriteRenderer objectHighlightSprite;

    //Other Object to check before showing Highlights
    public string ObjectToBeChecked;
    private GameObject objectCheck;
    private bool hasObjectToCheck;


    //Draggable Dragged Object Id
    public string ObjectId;


    private void Start()
    {
        
    }
    private void Awake()
    {
        //Find Highlight by Name
        if (ObjectHighlightName != string.Empty)
        {
            objectHighlight = GameObject.Find(ObjectHighlightName);
//            objectHighlightSprite = objectHighlight.GetComponent<SpriteRenderer>();
        }


        //Find Objects to be Checked
        if (ObjectToBeChecked != string.Empty)
        {
            objectCheck = GameObject.Find(ObjectToBeChecked);
            hasObjectToCheck = true;
        }


        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = transform.localPosition;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;  

        if(rectTransform.anchoredPosition == eventData.delta)
        {
            isDragging = true;
        }
         
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = startPosition;
        canvasGroup.blocksRaycasts = true;
        isDragging = false;
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        //SoundManager.PlaySound("click");
    }

    private void Update()
    {
        
        if (!hasObjectToCheck)
        {
            ToggleHighlight();
        }

        if (hasObjectToCheck)
        {
            ToggleHighlightCheckObject();
        }


    }

    private void ToggleHighlight()
    {
        if (objectHighlightSprite != null)
        {
            //Activate HighLight
            if (isDragging)
            {
                objectHighlightSprite.enabled = true;
            }

            //DeActivate HighLight
            if (!isDragging)
            {
                objectHighlightSprite.enabled = false;
            }
        }
    }

    private void ToggleHighlightCheckObject()
    {
        if (objectHighlightSprite != null)
        {
            //Activate HighLight
            if (isDragging && objectCheck == null)
            {
                objectHighlightSprite.enabled = true;
            }

            //DeActivate HighLight
            if (!isDragging && objectCheck == null)
            {
                objectHighlightSprite.enabled = false;
            }
        }
    }
}
