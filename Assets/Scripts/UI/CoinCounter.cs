using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    private TextMeshProUGUI text;
    private int coins = 0;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void Collect()
    {
        coins++;
        text.text = "Coins: " + coins;
    }

    public bool Debit(int amount)
    {
        if (coins - amount >= 0)
        {
            coins -= amount;
            text.text = "Coins: " + coins;
            return true;
        }
        return false;
    }
}
