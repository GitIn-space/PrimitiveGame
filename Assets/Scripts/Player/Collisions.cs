using TMPro;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    [SerializeField] private CoinCounter coins;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            coins.Collect();
            Destroy(collision.gameObject);
        }
    }
}
