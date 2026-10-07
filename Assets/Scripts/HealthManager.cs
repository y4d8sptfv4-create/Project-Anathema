using UnityEngine;
using UnityEngine.UI;

// Damage types which Karamir is vulnerable to
public enum DamageType
{
    EnemyDamage,
    SelfDamage,
    Other // Placeholder
}

public class HealthManager : MonoBehaviour
{
    [Header("Health Settings")]
    public float maxHealth = 100f;
    private float currentHealth;

    [Header("UI Reference")]
    public Slider healthBar;

    [Header("Audio Settings")]
    public AudioSource audioSource;
    public AudioClip enemyDamageSound; // EnemyDamage audio

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }

    // Updated to require a DamageType
    public void TakeDamage(float damageAmount, DamageType damageType)
    {
        // Only take Enemy and Self Damage
        if (damageType == DamageType.EnemyDamage || damageType == DamageType.SelfDamage)
        {
            currentHealth -= damageAmount;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            healthBar.value = currentHealth;

            // Play EnemyDamage audio
            if (damageType == DamageType.EnemyDamage && audioSource != null && enemyDamageSound != null)
            {
                audioSource.PlayOneShot(enemyDamageSound);
            }

            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        Debug.Log("Karamir got sleepy...");
    }
}