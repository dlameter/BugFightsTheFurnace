using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayArea : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("DROP IN PLAY AREA");
        GameObject bug = Instantiate(Resources.Load("Prefabs/AutoChessEntity"), eventData.pointerCurrentRaycast.worldPosition, Quaternion.identity) as GameObject;
    }
}
