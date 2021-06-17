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
    public BugRecipeBook recipeBook;

    public void MergeBugs()
    {
        if (firstSlot.cardInSlot != null && secondSlot.cardInSlot != null && outputSlot.cardInSlot == null)
        {
            foreach (BugRecipe recipe in recipeBook.recipes)
            {
                if (TestRecipe(recipe))
                {
                    Debug.Log("result " + recipe.resultingBug);
                    GameObject newCard = Instantiate(cardPrefab, Vector3.zero, Quaternion.identity, cardParent.transform) as GameObject;
                    newCard.GetComponent<Card>().bugStats = recipe.resultingBug;
                    outputSlot.SetCardInSlot(outputSlot, newCard.GetComponent<Card>());

                    firstSlot.DestoryCard();
                    secondSlot.DestoryCard();
                    return;
                }
            }
        }
    }

    private bool TestRecipe(BugRecipe recipe)
    {
        if (
            (recipe.baseBug == firstSlot.cardInSlot.bugStats &&
            recipe.additiveBug == secondSlot.cardInSlot.bugStats) // ||
            // (recipe[0] == secondSlot.cardInSlot.bugStats &&
            // recipe[1] == firstSlot.cardInSlot.bugStats)
            )
        {
            return true;
        }
        return false;
    }
}
