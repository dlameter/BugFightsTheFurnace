using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardSlot : MonoBehaviour, IDropHandler
{
    public BugStats bugInSlot;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("ON DROP");
        if (eventData.pointerDrag != null)
        {
            Card card = eventData.pointerDrag.GetComponent<Card>();
            if (card != null)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                SetBugInSlot(card.bugStats);
            }
        }
    }

    public void SetBugInSlot(BugStats bugStats)
    {
        bugInSlot = bugStats;
    }
}
