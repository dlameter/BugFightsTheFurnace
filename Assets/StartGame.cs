using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public void PauseAllAutoChessEntities()
    {
        List<AutoChessEntity> autoChessEntities = new List<AutoChessEntity>(Object.FindObjectsOfType<AutoChessEntity>());

        foreach (AutoChessEntity entity in autoChessEntities)
        {
            Rigidbody2D body = entity.GetComponent<Rigidbody2D>();
            body.Sleep();
        }
    }
    
    public void UnpauseAllAutoChessEntities()
    {
        List<AutoChessEntity> autoChessEntities = new List<AutoChessEntity>(Object.FindObjectsOfType<AutoChessEntity>());

        foreach (AutoChessEntity entity in autoChessEntities)
        {
            Rigidbody2D body = entity.GetComponent<Rigidbody2D>();
            body.sleepMode = RigidbodySleepMode2D.NeverSleep;
            body.WakeUp();
        }
    }
}
