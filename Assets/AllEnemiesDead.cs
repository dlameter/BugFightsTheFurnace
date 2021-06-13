using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AllEnemiesDead : MonoBehaviour
{
    public List<AutoChessEntity> enemies;
    public UnityEvent onWin;
    private int enemiesLeft;

    void Start()
    {
        enemiesLeft = enemies.Count;

        foreach (AutoChessEntity enemy in enemies)
        {
            enemy.onDead.AddListener(DecrementCounter);
        }
    }

    void DecrementCounter()
    {
        // enemiesLeft -= 1;

        enemies = enemies.FindAll((enemy) => {
            return enemy != null && !enemy.isDead();
        });

        // if (enemiesLeft <= 0)
        if (enemies.Count <= 0)
        {
            onWin.Invoke();
        }
    }
}
