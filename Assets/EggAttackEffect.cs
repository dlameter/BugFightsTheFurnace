using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EggAttackEffect : MonoBehaviour
{
    public GameObject from;
    public GameObject to;
    public LineRenderer line;
    public UnityEvent onHit;
    public float countdown = 1;

    void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0)
        {
            onHit.Invoke();
            Destroy(this.gameObject);
        }

        try
        {
            Vector3[] positions = { from.transform.position, to.transform.position };
            line.SetPositions(positions);
        }
        catch (MissingReferenceException)
        {
            Destroy(this.gameObject);
        }
    }
}
