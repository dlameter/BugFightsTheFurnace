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
        List<AutoChessEntity> autoChessEntities = new List<AutoChessEntity>(Object.FindObjectsOfType<AutoChessEntity>());
        autoChessEntities = autoChessEntities.FindAll((entity) => {
            return entity.enemy == true;
        });

        enemies = autoChessEntities;

        foreach (AutoChessEntity enemy in enemies)
        {
            enemy.onDead.AddListener(DecrementCounter);
        }
    }

    void DecrementCounter()
    {
        enemies = enemies.FindAll((enemy) => {
            return enemy != null && !enemy.isDead();
        });

        if (enemies.Count <= 0)
        {
            onWin.Invoke();
        }
    }
}
