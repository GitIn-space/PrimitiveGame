using UnityEngine;

public class Squish : MonoBehaviour
{
    private GameObject respawn;

    private void Awake()
    {
        respawn = GameObject.Find("PlayerSpawn");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.transform.position = respawn.transform.position;
    }
}
