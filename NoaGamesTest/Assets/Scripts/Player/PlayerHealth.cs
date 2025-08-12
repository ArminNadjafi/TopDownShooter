using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 20;
    public float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        UIManager.Instance.healthText.text = $"Health: {currentHealth}";
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log($"Player took {damage} damage. Current HP: {currentHealth}");
        UIManager.Instance.healthText.text = $"Health: {currentHealth}";
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player is dead!");
        gameObject.SetActive(false);
        UIManager.Instance.losePanel.SetActive(true);
    }
}