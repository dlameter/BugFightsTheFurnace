using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    void Start(){
        PauseAllAutoChessEntities();
    }
    public void PauseAllAutoChessEntities()
    {
        Time.timeScale = 0;
        List<AutoChessEntity> autoChessEntities = new List<AutoChessEntity>(Object.FindObjectsOfType<AutoChessEntity>());

        foreach (AutoChessEntity entity in autoChessEntities)
        {
            Rigidbody2D body = entity.GetComponent<Rigidbody2D>();
            body.Sleep();
        }
    }
    
    public static void UnpauseAllAutoChessEntities()
    {
        Time.timeScale = 1;
        List<AutoChessEntity> autoChessEntities = new List<AutoChessEntity>(Object.FindObjectsOfType<AutoChessEntity>());

        foreach (AutoChessEntity entity in autoChessEntities)
        {
            Rigidbody2D body = entity.GetComponent<Rigidbody2D>();
            body.sleepMode = RigidbodySleepMode2D.NeverSleep;
            body.WakeUp();
        }
    }
}
