using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private List<Transform> patrolPoints = new List<Transform>();
    [SerializeField] private float speed = 0;
    [SerializeField] private float minDist = 0.5f;
    [SerializeField] private float fallDelay = 3;

    private int index = 0;
    private Rigidbody2D body;
    private bool falling = true;
    private Coroutine fallRoutine;

    private void Awake()
    {
        body = gameObject.GetComponent<Rigidbody2D>();

        body.velocity = (patrolPoints[index].position - transform.position).normalized * speed * 2;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);

        Vector3 dist = patrolPoints[index].position - transform.position;

        if (++index >= patrolPoints.Count)
            index = 0;

        body.isKinematic = false;

        dist = patrolPoints[index].position - transform.position;
        body.velocity = dist.normalized * speed * 2;

        falling = true;

        fallRoutine = null;
    }

    private void Move()
    {
        if (!falling)
        {
            Vector3 dist = patrolPoints[index].position - transform.position;

            if ((dist.magnitude > minDist))
                return;
            else if (dist.magnitude < minDist && fallRoutine == null)
            {
                body.velocity = Vector2.zero;
                body.isKinematic = true;
                fallRoutine = StartCoroutine(Fall());
            }
        }
        else
        {
            Vector3 dist = patrolPoints[index].position - transform.position;

            if (dist.magnitude > minDist)
                return;
            else if (++index >= patrolPoints.Count)
                index = 0;

            dist = patrolPoints[index].position - transform.position;
            body.velocity = dist.normalized * speed / 2;

            falling = false;
        }
    }
}