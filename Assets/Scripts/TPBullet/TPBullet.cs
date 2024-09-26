using System.Net;
using UnityEngine;
using UnityEngine.InputSystem;

public class TPBullet : MonoBehaviour
{
    private Camera cam;
    private Rigidbody2D body;
    private Vector2 dir;
    private Pointer pointer;

    private float speed;
    public float Speed
    {
        set
        {
            speed = value;
        }

        get
        {
            return speed;
        }
    }

    private void OnTracker(InputValue input)
    {
        dir = input.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector2 lookDir = (cam.ScreenToWorldPoint(pointer.position.value) - transform.position);

        if (lookDir.magnitude <= 0.5f)
            return;

        transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90);

        body.velocity = transform.up * speed;
    }

    private void Awake()
    {
        cam = Camera.main;
        body = gameObject.GetComponent<Rigidbody2D>();
        pointer = Pointer.current;
    }
}
