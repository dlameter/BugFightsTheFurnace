using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackClosest : MonoBehaviour
{
    public AutoChessEntity bug;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(bug){
        AutoChessEntity otherBug = other.GetComponent<AutoChessEntity>();
        bug.bugStats.movementSpeed = 100;
        bug.receiveAttack(1f);
        Debug.Log("ATTACK!" + other.name + " from " + this.name + " other stats movement " /*+ otherStats.bugStats.movementSpeed*/);
        }
    }

    void OnTriggerStay2d(Collider2D other){
        Debug.Log("STAY BOY" + other.name + " from " + this.name + " other stats movement " /*+ otherStats.bugStats.movementSpeed*/);
        AutoChessEntity otherBug = other.GetComponent<AutoChessEntity>();
        bug.bugStats.movementSpeed = 100;
        bug.receiveAttack(1f);
        Debug.Log("STAY BOY" + other.name + " from " + this.name + " other stats movement " /*+ otherStats.bugStats.movementSpeed*/);
    }

    void OnTriggerLeave2d(Collider2D other){
        bug.bugStats.movementSpeed = 10;
    }
}
