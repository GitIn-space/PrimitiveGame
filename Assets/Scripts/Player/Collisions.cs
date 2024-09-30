using TMPro;
using UnityEngine;
using System.Collections;

public class Collisions : MonoBehaviour
{
    [SerializeField] private CoinCounter coins;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            coins.Collect();
            Destroy(collision.gameObject);
        }
    }
}
