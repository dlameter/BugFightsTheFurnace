using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackClosest : MonoBehaviour
{
    public AutoChessEntity bug;
    private float attackTimer;
    private AutoChessEntity lastOtherBug;

    // Update is called once per frame
    void Update()
    {
        attackTimer -= Time.deltaTime;

        // if(attackTimer <= 0){
        //     if(lastOtherBug){
        //         lastOtherBug.receiveAttack(bug.attack());
        //     }
        //     attackTimer = bug.bugStats.attackSpeed;
        // }
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
        if (otherBug != null && otherBug.tag == "Bug" && otherBug.enemy != bug.enemy)
        {
            StartGame.UnpauseAllAutoChessEntities();
            if (attackTimer <= 0) {
                Debug.Log(other.name + " got hit by " + bug.name);
                attackTimer = 1.0f / bug.bugStats.attackSpeed;
                otherBug.receiveAttack(bug.bugStats.attackPower);
            }
        }
    }

    void OnTriggerLeave2d(Collider2D other){
        // bug.bugStats.movementSpeed = 10;
    }
}
