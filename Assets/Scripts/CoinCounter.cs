using UnityEngine;
using TMPro; // Make sure you're using TextMeshPro

public class CoinCounter : MonoBehaviour
{
    public CoinManager coinManager;  // Reference to the CoinManager
    public TextMeshProUGUI coinText;  // Use TextMeshProUGUI for better text rendering

    private int lastCollectedCoins = -1;  // Store the last coin count to detect changes

    void Start()
    {
        // Update the text at the start
        UpdateCoinText();
    }

    void Update()
    {
        // Only update if the coin count has changed
        if (coinManager != null && coinManager.collectedCoins != lastCollectedCoins)
        {
            UpdateCoinText();
        }
    }

    // Function to update the coin text in the UI
    void UpdateCoinText()
    {
        if (coinManager != null && coinText != null)
        {
            coinText.text = "Coins: " + coinManager.collectedCoins + " / " + coinManager.totalCoins;
            lastCollectedCoins = coinManager.collectedCoins; // Update the cached coin count
        }
        else
        {
            Debug.LogWarning("CoinManager or CoinText is not set!");
        }
    }
}
