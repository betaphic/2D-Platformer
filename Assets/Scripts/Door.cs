using UnityEngine;
using UnityEngine.SceneManagement; // For scene management

public class Door : MonoBehaviour
{
    private string nextLevelName = "TheEnd";  // Fixed name for the next level/scene
    private CoinManager coinManager;  // Reference to the CoinManager script

    public bool requiresAllCoins = true;  // Whether all coins need to be collected to use the door

    void Start()
    {
        // Automatically find the CoinManager in the scene
        coinManager = FindObjectOfType<CoinManager>();

        if (coinManager == null)
        {
            Debug.LogWarning("CoinManager not found in the scene!");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player interacts with the door
        if (collision.CompareTag("Player"))
        {
            // Check if the player has collected all coins, if required
            if (requiresAllCoins && coinManager != null && coinManager.collectedCoins < coinManager.totalCoins)
            {
                Debug.Log("You need to collect all the coins to exit!");
            }
            else
            {
                // End the level
                EndLevel();
            }
        }
    }

    void EndLevel()
    {
        Debug.Log("Level Complete!");

        // Load the next level/scene
        SceneManager.LoadScene(nextLevelName);
    }
}
