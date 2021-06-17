using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New BugRecipe", menuName = "Bug/Bug Recipe")]
public class BugRecipe : ScriptableObject
{
    public BugStats baseBug;
    public BugStats additiveBug;

    public BugStats resultingBug;
}
