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
    }
    
    public static void UnpauseAllAutoChessEntities()
    {
        Time.timeScale = 1;
    }
}
