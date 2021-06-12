using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public static int MAX_CARDS = 10;
    public List<BugStats> bugList;

    public BugStats DrawCard()
    {
        int randomIndex = (int) Random.Range(0, bugList.Count);
        return bugList[randomIndex];
    }
}
