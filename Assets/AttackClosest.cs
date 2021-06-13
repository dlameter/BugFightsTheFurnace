using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackClosest : MonoBehaviour
{
    public AutoChessEntity bug;
    private float attackTimer;
    private AutoChessEntity lastOtherBug;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer -= Time.deltaTime;

        if(attackTimer <= 0){
            if(lastOtherBug){
                lastOtherBug.receiveAttack(bug.attack());
            }
            attackTimer = bug.bugStats.attackSpeed;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        // if(bug){
        // AutoChessEntity otherBug = other.GetComponent<AutoChessEntity>();
        // lastOtherBug = otherBug;
        // bug.bugStats.movementSpeed = 100;
        // bug.receiveAttack(1f);
        
        // // Start attack timer
        // attackTimer = bug.bugStats.attackSpeed;
        // }
    }

    void OnTriggerStay2D(Collider2D other){
        AutoChessEntity otherBug = other.GetComponent<AutoChessEntity>();
        if (otherBug != null && otherBug.enemy != bug.enemy)
        {
            bug.receiveAttack(1f);
            Debug.Log("STAY BOY" + other.name + " from " + this.name + " other stats movement " /*+ otherStats.bugStats.movementSpeed*/);
        }
    }

    void OnTriggerLeave2d(Collider2D other){
        bug.bugStats.movementSpeed = 10;
    }
}
