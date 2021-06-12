using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Deck : MonoBehaviour, IBeginDragHandler, IPointerDownHandler
{
    public static int MAX_CARDS = 10;
    public GameObject cardPrefab;
    public GameObject cardParent;
    public List<BugStats> bugList;

    public BugStats DrawCard()
    {
        int randomIndex = Mathf.RoundToInt(Random.Range(0, bugList.Count));
        return bugList[randomIndex];
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        BuildCard(DrawCard());
    }

    private GameObject BuildCard(BugStats bugStats)
    {
        GameObject cardObject = Instantiate(cardPrefab, this.GetComponent<RectTransform>().anchoredPosition, Quaternion.identity, cardParent.transform) as GameObject;
        cardObject.GetComponent<Card>().bugStats = bugStats;
        return cardObject;
    }
}
