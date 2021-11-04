using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] GameEvent swipeLeftEvent;
    [SerializeField] GameEvent swipeRightEvent;

    Vector2 startPos;

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPos = eventData.position;
    }
    
    public void OnDrag(PointerEventData eventData)
    {

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (startPos.x >= eventData.position.x)
        {
            swipeLeftEvent.Raise();
        }
        else if (startPos.x < eventData.position.x)
        {
            swipeRightEvent.Raise();
        }
    }
}
