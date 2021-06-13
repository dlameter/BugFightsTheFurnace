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
    public List<BugStats> bugList;

    public Dictionary<BugStats, BugStats[]> recipes = new Dictionary<BugStats, BugStats[]>();

    // Start is called before the first frame update
    void Start()
    {
        BugStats[] recipe;

        // Big Mosquito
        recipe = new BugStats[2];
        recipe[0] = bugList[0];
        recipe[1] = bugList[0];
        recipes.Add(bugList[1], recipe);

        // Big Mantis
        recipe = new BugStats[2];
        recipe[0] = bugList[2];
        recipe[1] = bugList[2];
        recipes.Add(bugList[3], recipe);

        // Big Egg
        recipe = new BugStats[2];
        recipe[0] = bugList[4];
        recipe[1] = bugList[4];
        recipes.Add(bugList[5], recipe);

        // Big Maggot
        recipe = new BugStats[2];
        recipe[0] = bugList[6];
        recipe[1] = bugList[6];
        recipes.Add(bugList[7], recipe);

        // Green Mosquito
        recipe = new BugStats[2];
        recipe[0] = bugList[0];
        recipe[1] = bugList[2];
        recipes.Add(bugList[8], recipe);

        // Healthy Mosquito
        recipe = new BugStats[2];
        recipe[0] = bugList[0];
        recipe[1] = bugList[4];
        recipes.Add(bugList[9], recipe);

        // Orange Mosquito
        recipe = new BugStats[2];
        recipe[0] = bugList[0];
        recipe[1] = bugList[6];
        recipes.Add(bugList[10], recipe);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MergeBugs()
    {
        if (firstSlot.cardInSlot != null && secondSlot.cardInSlot != null && outputSlot.cardInSlot == null)
        {
            foreach (BugStats result in recipes.Keys)
            {
                if (TestRecipe(recipes[result]))
                {
                    Debug.Log("result " + result);
                    GameObject newCard = Instantiate(cardPrefab, Vector3.zero, Quaternion.identity, cardParent.transform) as GameObject;
                    newCard.GetComponent<Card>().bugStats = result;
                    outputSlot.SetCardInSlot(outputSlot, newCard.GetComponent<Card>());

                    firstSlot.DestoryCard();
                    secondSlot.DestoryCard();
                    return;
                }
            }
        }
    }

    private bool TestRecipe(BugStats[] recipe)
    {
        if ((recipe[0] == firstSlot.cardInSlot.bugStats &&
            recipe[1] == secondSlot.cardInSlot.bugStats) ||
            (recipe[0] == secondSlot.cardInSlot.bugStats &&
            recipe[1] == firstSlot.cardInSlot.bugStats))
        {
            return true;
        }
        return false;
    }
}
