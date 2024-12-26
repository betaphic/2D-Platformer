using UnityEngine;

public class Coin : MonoBehaviour
{
    public CoinManager coinManager;  // Reference to the CoinManager
    public AudioClip collectSound;  // Drag and drop the coin sound effect in the Inspector
    private AudioSource audioSource;  // Audio source for playing sounds

    void Start()
    {
        // Try to find an AudioSource attached to the Coin
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogWarning("AudioSource not found on Coin! Add one to play sound effects.");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Play collect sound
            if (audioSource != null && collectSound != null)
            {
                audioSource.PlayOneShot(collectSound);
            }

            // Update CoinManager
            if (coinManager != null)
            {
                coinManager.CollectCoin();
            }
            else
            {
                Debug.LogWarning("CoinManager is not assigned!");
            }

            // Destroy the coin
            Destroy(gameObject);
        }
    }
}
