using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHide : MonoBehaviour
{
    public CanvasGroup group;
    void Start()
    {
        Hide();
    }

    public void Show() {
        group.alpha = 1;
    }

    public void Hide() {
        group.alpha = 0;
    }
}
