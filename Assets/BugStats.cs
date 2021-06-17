using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bug", menuName = "Bug/Bug Stats")]
public class BugStats : ScriptableObject
{
    public Sprite image;

    public GameObject bugPrefab;

    // Offensive
    public float attackPower;
    public float attackSpeed;

    public float movementSpeed;
    public float range;

    // Defensive
    public float hitpoints;

    public float defense;
    public float dodge;

    // Not implemented
    public float specialCooldownLength;

    public new string ToString() {
        return name + ": movement speed = " + movementSpeed;
    }
}
