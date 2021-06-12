using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoChessEntity : MonoBehaviour
{
    public BugStats bugStats;
    public SpriteRenderer bugRenderer;
    public GotoClosest gotoClosest;

    void Start() {
        bugRenderer.sprite = bugStats.image;
        gotoClosest.bugStats = bugStats;
    }
}
