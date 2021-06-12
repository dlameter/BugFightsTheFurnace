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

    public void receiveAttack(float damage, float special = 0)
    {
        bool dodgeBool = (Random.Range(bugStats.dodge, 100) >= 90);

        if (!dodgeBool)
        {
            Debug.Log("HP = " + bugStats.hitpoints + " dodged: " + dodgeBool);
            bugStats.hitpoints = bugStats.hitpoints + (bugStats.defense - damage);
        }

        if (bugStats.hitpoints <= 0)
        {
            die();
        }
    }

    public float attack()
    {
        float damage = bugStats.attackPower;

        return damage;
    }

    public void die()
    {
        Debug.Log("Dead: " + name);
        Destroy(this.gameObject);
    }

    public void specialAttack() { }
}
