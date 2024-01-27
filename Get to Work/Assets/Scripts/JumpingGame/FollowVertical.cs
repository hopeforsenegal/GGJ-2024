using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowVertical : MonoBehaviour
{
    public GameObject Target;
    public float Offset;

    private void Update()
    {
        transform.position = new Vector3(
            transform.position.x,
            Target.transform.position.y + Offset,
            transform.position.z);
    }
}
