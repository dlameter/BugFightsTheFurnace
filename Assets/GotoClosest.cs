using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotoClosest : MonoBehaviour
{
    public float speed;
    public float stopDistance;
    public bool friend;

    private HashSet<Collider2D> colliding = new HashSet<Collider2D>();

    void FixedUpdate()
    {
        Transform closest = GetClosestTransform(new List<Collider2D>(colliding).ConvertAll<Transform>(Collider2DToTransform));
        Debug.Log(closest);
        MoveTo(closest);
    }

    void MoveTo(Transform transform)
    {
        Rigidbody2D body = this.GetComponent<Rigidbody2D>();
        if (body)
        {
            Vector3 position = body.position;
            Vector3 otherPosition = transform.position;
            Vector3 difference = otherPosition - position;

            if (Vector3.Distance(position, otherPosition) > stopDistance)
            {
                body.velocity = difference.normalized * speed * Time.deltaTime;
            }
            else
            {
                body.velocity = Vector2.zero;
            }
        }
    }

    Transform Collider2DToTransform(Collider2D collider)
    {
        return collider.transform;
    }

    Transform GetClosestTransform(List<Transform> transforms)
    {
        Rigidbody2D body = this.GetComponent<Rigidbody2D>();
        if (!body || transforms.Count == 0)
        {
            return null;
        }
        Transform closest = transforms[0];

        foreach (Transform transform in transforms)
        {
            if (Vector3.Distance(body.transform.position, transform.position) < Vector3.Distance(body.transform.position, closest.position))
            {
                closest = transform;
            }
        }

        return closest;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bug")
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
