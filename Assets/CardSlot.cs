using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class CardSlot : MonoBehaviour, IDropHandler
{
    public Card cardInSlot;
    public UnityEvent<Card> onCardAdded;
    public UnityEvent<Card> onCardRemoved;

    void Start()
    {
        if (cardInSlot != null)
        {
            SetCardInSlot(this, cardInSlot);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("ON DROP");
        if (eventData.pointerDrag != null)
        {
            Card newCard = eventData.pointerDrag.GetComponent<Card>();

            if (newCard != null)
            {
                if (cardInSlot)
                {
                    onCardRemoved.Invoke(cardInSlot);
                    SwitchCards(cardInSlot, newCard);
                    onCardAdded.Invoke(cardInSlot);
                }
                else
                {
                    SetCardInSlot(this, newCard);
                }
            }
        }
    }

    public void SetCardInSlot(CardSlot slot, Card card)
    {
        CardSlot currentSlot = card.GetSlot();
        if (currentSlot != null && currentSlot.cardInSlot != null && currentSlot.cardInSlot == card)
        {
            currentSlot.cardInSlot = null;
        }

        card.GetComponent<RectTransform>().anchoredPosition = slot.GetComponent<RectTransform>().anchoredPosition;
        slot.cardInSlot = card;
        card.SetSlot(slot);
    }

    private void SwitchCards(Card oldCard, Card newCard)
    {
        SetCardInSlot(newCard.GetSlot(), oldCard);
        SetCardInSlot(this, newCard);
    }
}
