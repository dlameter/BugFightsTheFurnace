using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bug", menuName = "Bug")]
public class BugStats : ScriptableObject
{
    public new string name;
    public Sprite image;

    public float movementSpeed;
    public float attackPower;
    public float attackSpeed;
    public float defense;
    public float health;
    public float dodge;
    public float specialCooldownLength;

    public new string ToString() {
        return name + ": movement speed = " + movementSpeed;
    }
}
