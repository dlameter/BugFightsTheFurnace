using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TargetingInterface : MonoBehaviour
{
    public abstract Transform targetingFunction(List<Transform> transforms, Rigidbody2D body);
}
