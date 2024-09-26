using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private List<Transform> patrolPoints = new List<Transform>();
    [SerializeField] private float speed = 0;
    [SerializeField] private float minDist = 0.5f;

    private int index = 0;
    private Rigidbody2D body;

    // move and explode

    private void Awake()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if ((transform.position - patrolPoints[index].position).magnitude <= minDist)
            if (++index >= patrolPoints.Count)
                index = 0;

        body.velocity = (patrolPoints[index].position - transform.position).normalized * speed;
    }
}
