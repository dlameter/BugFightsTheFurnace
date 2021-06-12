using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayArea : MonoBehaviour, IDropHandler
{
    public GameObject prefab;

    public void OnDrop(PointerEventData eventData)
    {
        Card card = eventData.pointerDrag.GetComponent<Card>();
        if (card != null) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(eventData.position);
            mousePos.z = 0;
            GameObject bug = Instantiate(card.bugStats.bugPrefab, mousePos, Quaternion.identity) as GameObject;
            Destroy(card.gameObject);
        }
    }
}
