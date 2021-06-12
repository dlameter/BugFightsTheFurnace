using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public BugStats bugStats;
    public Image image;
    public Text bugName;
    public RectTransform previousPosition;
    public CardSlot currentSlot;

    void Start()
    {
        bugName.text = bugStats.name;
        image.sprite = bugStats.image;
        previousPosition = GetComponent<RectTransform>();
    }
}
