using UnityEngine;
using TMPro;

public class PowerUpUI : MonoBehaviour
{
    public enum PowerUpType
    {
        Heal,
        SpeedBoost,
        Shield,
        DamageBoost
    }

    [Header("References")]
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private TMP_InputField valueInput;
    [SerializeField] private TMP_Text messageText;

    private PowerUpType selectedPowerUp;

    public void SelectHeal() => SelectPowerUp(PowerUpType.Heal);
    public void SelectSpeedBoost() => SelectPowerUp(PowerUpType.SpeedBoost);
    public void SelectShield() => SelectPowerUp(PowerUpType.Shield);
    public void SelectDamageBoost() => SelectPowerUp(PowerUpType.DamageBoost);

    private void SelectPowerUp(PowerUpType powerUp)
    {
        selectedPowerUp = powerUp;
        messageText.text = $"Seleccionado: {selectedPowerUp}";
    }
}