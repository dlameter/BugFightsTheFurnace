using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotoClosest : MonoBehaviour
{
    public Rigidbody2D body;
    public AutoChessEntity autoChessEntity;
    public BugStats bugStats;
    public float stopDistance;
    public TargetingInterface targetingClass;

    private HashSet<Collider2D> colliding = new HashSet<Collider2D>();

    void FixedUpdate()
    {
        if (colliding.Count > 0)
        {
            Transform closest = targetingClass.targetingFunction(
                new List<Collider2D>(colliding).FindAll((colliders) =>
                {
                    return colliders != null;
                })
                .ConvertAll<Transform>(Collider2DToTransform),
                this.GetComponentInParent<Rigidbody2D>()
            );
            MoveTo(closest);
            LookAt(closest);
        }
    }

    void MoveTo(Transform transform)
    {
        if (!transform || !body)
        {
            body.velocity = Vector2.zero;
            return;
        }
        Vector3 position = body.position;
        Vector3 otherPosition = transform.position;
        Vector3 difference = otherPosition - position;

        if (Vector3.Distance(position, otherPosition) > stopDistance)
        {
            body.velocity = difference.normalized * bugStats.movementSpeed * Time.deltaTime;
        }
        else
        {
            body.velocity = Vector2.zero;
        }
    }

    void LookAt(Transform transform)
    {
        if (!transform || !body)
        {
            return;
        }
        float angle = Vector3.SignedAngle(Vector3.up, body.transform.position - transform.position, Vector3.forward);
        body.MoveRotation(angle);
    }

    Transform Collider2DToTransform(Collider2D collider)
    {
        return collider.transform;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        AutoChessEntity otherChessEntity = other.GetComponent<AutoChessEntity>();
        if (other.gameObject.tag == "Bug" && otherChessEntity != null && otherChessEntity.enemy != autoChessEntity.enemy) 
        {
            this.colliding.Add(other);
        }
    }

    void OnTriggerLeave2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bug")
        {
            this.colliding.Remove(other);
        }
    }
}
