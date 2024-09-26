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
}
