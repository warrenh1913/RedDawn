using UnityEngine;
using TMPro;

public class Player_Health : MonoBehaviour
{
    public float health = 100f;
    public TextMeshProUGUI healthText;

    void Start()
    {
        UpdateUI();
    }

    public void Heal(float amount)
    {
        health += amount;
        if (health > 100f)
            health = 100f;

        UpdateUI();
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
            health = 0f;

        UpdateUI();

        if (health <= 0f)
        {
            Debug.Log("Player died");
        }
    }

    void UpdateUI()
    {
        if (healthText != null)
            healthText.text = "Health: " + health;
    }
}