using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootFollow : MonoBehaviour
{
    public Transform target;
    private bool following = false;
    public float minModifier;
    public float maxModifier;

    Vector3 velocity = Vector3.zero;

    public void StartFollowing()
    {
        following = true;
    }

    private void Update()
    {
        if (following)
        {
            transform.position = Vector3.SmoothDamp
                (transform.position, target.position, ref velocity, Time.deltaTime * Random.Range(minModifier, maxModifier));
        }
    }
}
