using UnityEngine;
using UnityEngine.InputSystem;

public class Input : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    [SerializeField] private float gravityscale;
    [SerializeField] private GameObject tpBullet;
    [SerializeField] private float tpBulletSpeed = 1;

    private float dir;
    private Rigidbody2D body;
    private SpriteRenderer sprite;
    private Collider2D collider;
    private Pointer pointer;
    private Camera cam;
    private Rigidbody2D tpBulletObj;

    private void Move()
    {
        Vector3 velocity = new Vector3();

        if (dir != 0)
            velocity += transform.right * dir * speed;

        body.velocity = velocity;
    }

    private void Gravity()
    {
        body.velocity += new Vector2(0, -1) * gravityscale;
    }

    private void Awake()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        collider = gameObject.GetComponent<Collider2D>();

        pointer = Pointer.current;
        cam = Camera.main;
    }

    private void FixedUpdate()
    {
        Move();

        Gravity();
    }

    private void OnMove(InputValue input)
    {
        dir = input.Get<float>();
    }

    private void OnTeleport(InputValue input)
    {
        if (input.isPressed)
        {
            body.isKinematic = true;
            sprite.enabled = false;
            collider.enabled = false;

            tpBulletObj = Instantiate(tpBullet).GetComponent<Rigidbody2D>();
            Vector2 lookDir = (cam.ScreenToWorldPoint(pointer.position.value) - transform.position).normalized;

            tpBulletObj.transform.position = transform.position;
            tpBulletObj.transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90);

            tpBulletObj.velocity = tpBulletObj.transform.up * tpBulletSpeed;
            tpBulletObj.GetComponent<TPBullet>().Speed = tpBulletSpeed;
        }
        else
        {
            body.isKinematic = false;
            sprite.enabled = true;
            collider.enabled = true;

            transform.position = tpBulletObj.transform.position;
            Destroy(tpBulletObj.gameObject);
        }
    }
}
