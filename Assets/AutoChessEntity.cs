using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class AutoChessEntity : MonoBehaviour
{
    public BugStats bugStats;
    public SpriteRenderer bugRenderer;
    public GotoClosest gotoClosest;
    public AttackClosest attackClosest;
    public bool enemy;
    private float hp;

    public UnityEvent onDead;

    void Start()
    {
        bugRenderer.sprite = bugStats.image;
        gotoClosest.bugStats = bugStats;
        hp = bugStats.hitpoints;
        if (bugStats.range > 0)
        {
            attackClosest.GetComponent<CircleCollider2D>().radius = bugStats.range;
        }
    }

    public void receiveAttack(float damage, float special = 0)
    {
        Animator animator = GetComponent<Animator>();

        bool dodgeBool = (Random.Range(0, 100) <= bugStats.dodge);

        if (!dodgeBool)
        {
            Debug.Log(bugStats.name + ": HP = " + hp + " dodged: " + dodgeBool);
            hp -= Mathf.Max(damage - bugStats.defense, 1);
            animator.SetTrigger("hit");

            if (hp <= 0)
            {
                animator.SetTrigger("die");
                dying();
            }
        }
    }

    public float attack()
    {
        float damage = bugStats.attackPower;

        return damage;
    }

    public void dying()
    {
        Destroy(gotoClosest);
        Destroy(attackClosest);
    }

    public void die()
    {
        Destroy(this.gameObject);
    }

    void OnDestroy()
    {
        onDead.Invoke();
    }

    public bool isDead()
    {
        return hp <= 0;
    }

    public void specialAttack() { }
}
