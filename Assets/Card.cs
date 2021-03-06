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
    public Text range;
    public Text maxHealth;
    public Text attack;
    public Text attackSpeed;
    public Text defense;
    public Text dodge;
    private Vector2 previousPosition;
    private CardSlot currentSlot;

    void Start()
    {
        bugName.text = bugStats.name;
        range.text = "" + bugStats.range;
        maxHealth.text = "" + bugStats.hitpoints;
        attack.text = "" + bugStats.attackPower;
        attackSpeed.text = string.Format("{0:0.00}", 1 / bugStats.attackSpeed);
        defense.text = "" + bugStats.defense;
        dodge.text = string.Format("{0}%", bugStats.dodge);
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

    public void EndDrag()
    {
        if (currentSlot != null && currentSlot.cardInSlot != this)
        {
            SetSlot(null);
        }
    }

    public void ClearSlot()
    {
        if (currentSlot != null)
        {
            currentSlot.SetCardInSlot(currentSlot, null);
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
        if (newSlot != null)
        {
            SetPreviousPosition(newSlot.GetComponent<RectTransform>());
        }
        else
        {
            SetPreviousPosition(GetComponent<RectTransform>());
        }
    }

    public CardSlot GetSlot()
    {
        return currentSlot;
    }

    private void SetPreviousPosition(RectTransform newPosition)
    {
        previousPosition = newPosition.anchoredPosition;
    }

    public Vector2 GetPreviousPosition()
    {
        return previousPosition;
    }
}
