using UnityEngine;

public class Hazard : MonoBehaviour
{
    [Header("Hazard Settings")]
    public float damageAmount = 15f;

    // Triggered when Karamir walks into the hazard
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object touching the thorns is karamir
        if (collision.CompareTag("Player"))
        {
            HealthManager playerHealth = collision.GetComponent<HealthManager>();
            
            if (playerHealth != null)
            {
                // Send the Damage amount which is specifically Enemy
                playerHealth.TakeDamage(damageAmount, DamageType.EnemyDamage);
            }
        }
    }
}