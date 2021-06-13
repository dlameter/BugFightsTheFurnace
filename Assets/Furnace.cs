using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furnace : MonoBehaviour
{
    public GameObject cardPrefab;
    public GameObject cardParent;
    public CardSlot firstSlot;
    public CardSlot secondSlot;
    public CardSlot outputSlot;
    public BugStats newCardBugStats;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MergeBugs() {
        GameObject newCard = Instantiate(cardPrefab, Vector3.zero, Quaternion.identity, cardParent.transform) as GameObject;
        newCard.GetComponent<Card>().bugStats = newCardBugStats;
        outputSlot.SetCardInSlot(outputSlot, newCard.GetComponent<Card>());
    }
}
