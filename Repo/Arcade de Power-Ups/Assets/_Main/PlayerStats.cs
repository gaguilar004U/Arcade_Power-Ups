using UnityEngine;
public class PlayerStats : MonoBehaviour
{
[Header("Health")]
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float currentHealth = 100f;

    [Header("Speed")]
    [SerializeField] private float baseSpeed = 5f;
    [SerializeField] private float currentSpeed = 5f;

    [Header("Shield")]
    [SerializeField] private bool hasShield = false;

    public float MaxHealth => maxHealth;
    public float CurrentHealth => currentHealth;
    public float CurrentSpeed => currentSpeed;
    public bool HasShield => hasShield;

    //Metodos

        public void Heal(float amount)
    {
        if (amount <= 0) return;
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
    }

    public void SetSpeedMultiplier(float multiplier)
    {
        if (multiplier <= 0) return;
        currentSpeed = baseSpeed * multiplier;
    }

    public void SetShield(bool active)
    {
        hasShield = active;
    }
}