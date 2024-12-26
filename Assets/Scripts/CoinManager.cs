using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public int totalCoins = 5;  // Total number of coins in the level
    public int collectedCoins = 0;  // Number of coins the player has collected

    // Call this function when a coin is collected
    public void CollectCoin()
    {
        collectedCoins++;
        // If all coins are collected, you can trigger the game over
        if (collectedCoins >= totalCoins)
        {
            // Call Game Over logic or show a message
            GameOver();
        }
    }

    // Game Over logic
    void GameOver()
    {
        Debug.Log("Game Over! All coins collected.");
        // You could also trigger UI changes here, like showing a Game Over text
    }
}
