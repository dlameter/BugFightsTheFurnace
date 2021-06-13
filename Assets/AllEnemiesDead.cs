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
        enemiesLeft -= 1;

        if (enemiesLeft <= 0)
        {
            onWin.Invoke();
        }
    }
}
