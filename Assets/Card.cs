using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IDropHandler
{
    public BugStats bugStats;
    public Image image;
    public Text bugName;
    private Vector2 previousPosition;
    private CardSlot currentSlot;

    void Start()
    {
        bugName.text = bugStats.name;
        image.sprite = bugStats.image;
        SetPreviousPosition(GetComponent<RectTransform>());
    }

    public void OnDrop()
    {
        if (!ChangedSlot())
        {
            ReturnToPosition();
        }
    }

    public void ReturnToPosition()
    {
        GetComponent<RectTransform>().anchoredPosition = previousPosition;
    }

    public bool ChangedSlot()
    {
        if (currentSlot == null)
        {
            return true;
        }
        else
        {
            return !previousPosition.Equals(currentSlot.GetComponent<RectTransform>().anchoredPosition);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (currentSlot != null)
        {
            ((IDropHandler)currentSlot).OnDrop(eventData);
        }
    }

    public void SetSlot(CardSlot newSlot)
    {
        currentSlot = newSlot;
        SetPreviousPosition(newSlot.GetComponent<RectTransform>());
    }

    public CardSlot GetSlot()
    {
        return currentSlot;
    }

    private void SetPreviousPosition(RectTransform newPosition) {
        previousPosition = newPosition.anchoredPosition;
    }
}
