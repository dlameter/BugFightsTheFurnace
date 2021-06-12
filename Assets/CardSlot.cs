using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardSlot : MonoBehaviour, IDropHandler
{
    public Card cardInSlot;

    void Start()
    {
        cardInSlot.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("ON DROP");
        if (eventData.pointerDrag != null)
        {
            Card card = eventData.pointerDrag.GetComponent<Card>();

            if (card != null)
            {
                if (cardInSlot)
                {
                    SwitchCards(cardInSlot, card);
                }
                else
                {
                    SetCardInSlot(this, card);
                }
            }
        }
    }

    public void SetCardInSlot(CardSlot slot, Card card)
    {
        if (card.currentSlot != null && card.currentSlot.cardInSlot != null) {
            card.currentSlot.cardInSlot = null;
        }

        card.GetComponent<RectTransform>().anchoredPosition = slot.GetComponent<RectTransform>().anchoredPosition;
        slot.cardInSlot = card;
        card.currentSlot = slot;
    }

    private void SwitchCards(Card oldCard, Card newCard)
    {
        SetCardInSlot(newCard.currentSlot, oldCard);
        SetCardInSlot(this, newCard);
    }
}
