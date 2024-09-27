using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private List<Transform> patrolPoints = new List<Transform>();
    [SerializeField] private float speed = 0;
    [SerializeField] private float minDist = 0.5f;
    [SerializeField] private float colourCycle = 3f;

    private int index = 0;
    private Rigidbody2D body;
    private SpriteRenderer sprite;

    // move and explode

    private void Awake()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
        sprite = gameObject.GetComponent<SpriteRenderer>();

        body.velocity = (patrolPoints[index].position - transform.position).normalized * speed;

        StartCoroutine(Explode());
    }

    private void FixedUpdate()
    {
        Vector3 dist = patrolPoints[index].position - transform.position;

        if ((dist.magnitude > minDist))
            return;
        else
            if (++index >= patrolPoints.Count)
                index = 0;

        dist = patrolPoints[index].position - transform.position;
        body.velocity = dist.normalized * speed;
    }

    private IEnumerator Explode()
    {
        float r = 0;
        while (true)
        {
            yield return new WaitForSeconds(255/colourCycle);

            r += (255 / colourCycle);

            if(r > 255)
            {
                //make boom
                r %= 255;
            }

            sprite.color = new Color(r, 0, 0);
        }
    }
}
