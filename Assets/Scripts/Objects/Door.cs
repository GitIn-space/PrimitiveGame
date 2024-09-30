using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private CoinCounter coins;
    [SerializeField] private int cost = 1;

    private bool isAnimating = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            if (!isAnimating)
                if (coins.Debit(cost))
                {
                    isAnimating = true;
                    StartCoroutine(MoveDoor());
                }
    }

    private IEnumerator MoveDoor(bool up = true)
    {
        for (int c = 0; c < 5; c++)
        {
            yield return new WaitForSeconds(0.5f);

            transform.position += new Vector3(0, up ? 0.5f : -0.5f, 0);
        }
        if (up)
            StartCoroutine(WaitDoor());
        else
            isAnimating = false;
    }

    private IEnumerator WaitDoor()
    {
        yield return new WaitForSeconds(3f);
        StartCoroutine(MoveDoor(false));
    }
}
