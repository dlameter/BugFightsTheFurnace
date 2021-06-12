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
    private RectTransform previousPosition;
    private CardSlot currentSlot;

    void Start()
    {
        bugName.text = bugStats.name;
        image.sprite = bugStats.image;
        previousPosition = Instantiate(GetComponent<RectTransform>());
    }

    public void OnDrop()
    {
        Debug.Log("Card dropped");
        if (!ChangedSlot())
        {
            ReturnToPosition();
        }
    }

    public void SetSlot(CardSlot newSlot)
    {
        currentSlot = newSlot;
        previousPosition = newSlot.GetComponent<RectTransform>();
    }

    public CardSlot GetSlot()
    {
        return currentSlot;
    }

    public void ReturnToPosition()
    {
        GetComponent<RectTransform>().anchoredPosition = previousPosition.anchoredPosition;
    }

    public bool ChangedSlot()
    {
        if (currentSlot == null)
        {
            return true;
        }
        else
        {
            return !previousPosition.Equals(currentSlot.GetComponent<RectTransform>());
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (currentSlot != null)
        {
            ((IDropHandler)currentSlot).OnDrop(eventData);

        }
    }
}
