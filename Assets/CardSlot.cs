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
                    if (newCard.GetSlot() == null)
                    {
                        Debug.Log("swap positions");
                        SwapPositions(cardInSlot, newCard);
                    }
                    else
                    {
                        onCardRemoved.Invoke(cardInSlot);
                        SwitchCards(cardInSlot, newCard);
                        onCardAdded.Invoke(cardInSlot);
                    }
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
        if (card == null)
        {
            slot.cardInSlot = null;
            return;
        }

        CardSlot currentSlot = card.GetSlot();
        if (currentSlot != null && currentSlot.cardInSlot != null && currentSlot.cardInSlot == card)
        {
            currentSlot.cardInSlot = null;
        }

        RectTransform cardTransform = card.GetComponent<RectTransform>();
        RectTransform slotTransform = slot.GetComponent<RectTransform>();

        cardTransform.anchoredPosition = slotTransform.anchoredPosition;
        slot.cardInSlot = card;
        card.SetSlot(slot);
    }

    public void DestoryCard() {
        Card card = cardInSlot;
        SetCardInSlot(this, null);
        Destroy(card.gameObject);
    }

    private void SwitchCards(Card oldCard, Card newCard)
    {
        SetCardInSlot(newCard.GetSlot(), oldCard);
        SetCardInSlot(this, newCard);
    }

    private void SwapPositions(Card inSlotCard, Card outOfSlotCard)
    {
        // Add new card to this slot
        Vector2 prevPos = outOfSlotCard.GetPreviousPosition();
        SetCardInSlot(this, outOfSlotCard);

        // Move old card to new cards previous position
        inSlotCard.GetComponent<RectTransform>().anchoredPosition = prevPos;

        // Clear old card's slot
        inSlotCard.SetSlot(null);
    }
}
