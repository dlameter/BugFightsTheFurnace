using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoChessEntity : MonoBehaviour
{
    public BugStats bugStats;
    public SpriteRenderer bugRenderer;
    public GotoClosest gotoClosest;
    public bool enemy;
    private float hp;

    void Start() {
        bugRenderer.sprite = bugStats.image;
        gotoClosest.bugStats = bugStats;
        hp = bugStats.health;
    }

    public void receiveAttack(float damage, float special = 0)
    {
        bool dodgeBool = (Random.Range(0, 100) <= bugStats.dodge);

        if (!dodgeBool)
        {
            Debug.Log(bugStats.name + ": HP = " + hp + " dodged: " + dodgeBool);
            hp -= Mathf.Max(damage - bugStats.defense, 1);
        }

        if (hp <= 0)
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
