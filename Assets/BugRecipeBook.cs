using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New BugRecipe", menuName = "Bug/Bug RecipeBook")]
public class BugRecipeBook : ScriptableObject
{
    [SerializeField]
    public List<BugRecipe> recipes;
}
