using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFarthest : TargetingInterface 
{
    public override Transform targetingFunction(List<Transform> transforms, Rigidbody2D body)
    {
        if (transforms.Count == 0)
        {
            return null;
        }
        Transform farthest = transforms[0];

        foreach (Transform transform in transforms)
        {
            if (Vector3.Distance(body.transform.position, transform.position) > Vector3.Distance(body.transform.position, farthest.position))
            {
                farthest = transform;
            }
        }

        return farthest;
    }
}
