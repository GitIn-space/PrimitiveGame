using UnityEngine;

public class Coin : MonoBehaviour
{
    private Spawner callback;
    public Spawner Callback
    {
        get
        {
            return callback;
        }
        set
        {
            callback = value;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            callback.Spawned = false;
    }
}
