using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bug", menuName = "Bug")]
public class BugStats : ScriptableObject
{
    public Sprite image;

    public GameObject bugPrefab;
    public float movementSpeed;
    public float attackPower;
    public float attackSpeed;
    public float defense;
    public float health;
    public float hitpoints;
    public float dodge;
    public float range;
    public float specialCooldownLength;

    public new string ToString() {
        return name + ": movement speed = " + movementSpeed;
    }
}
