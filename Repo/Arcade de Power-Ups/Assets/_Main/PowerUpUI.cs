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

    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private TMP_InputField valueInput;
    [SerializeField] private TMP_Text messageText;
    private PowerUpType selectedPowerUp;

    //selección
    public void SelectHeal() => SelectPowerUp(PowerUpType.Heal);
    public void SelectSpeedBoost() => SelectPowerUp(PowerUpType.SpeedBoost);
    public void SelectShield() => SelectPowerUp(PowerUpType.Shield);
    public void SelectDamageBoost() => SelectPowerUp(PowerUpType.DamageBoost);

    private void SelectPowerUp(PowerUpType powerUp)
    {
        selectedPowerUp = powerUp;
        messageText.text = $"Seleccionado: {selectedPowerUp}";
    }

    //Boton aplicar
    public void ApplySelectedPowerUp()
    {
        if (!ValidateReferences())
            return;

        if (!TryReadValue(out float value))
            return;

        if (!ValidateRules(value))
            return;

        ApplyPowerUp(value);
    }

    //Validar
    private bool ValidateReferences()
    {
        if (playerStats == null || valueInput == null || messageText == null)
        {
            Debug.LogError("Faltan referencias en PowerUpUI");
            return false;
        }
        return true;
    }

    private bool TryReadValue(out float value)
    {
        if (!float.TryParse(valueInput.text, out value))
        {
            messageText.text = "Error: el valor ingresado no es un número válido.";
            return false;
        }

        return true;
    }

    private bool ValidateRules(float value)
    {
        if (value <= 0)
        {
            messageText.text = "Error: el valor debe ser mayor que 0.";
            return false;
        }

        switch (selectedPowerUp)
        {
            case PowerUpType.Heal:
                if (playerStats.CurrentHealth >= playerStats.MaxHealth)
                {
                    messageText.text = "La vida ya está al máximo.";
                    return false;
                }
                break;

            case PowerUpType.Shield:
                if (playerStats.HasShield)
                {
                    messageText.text = "El escudo ya está activo.";
                    return false;
                }
                break;
        }

        return true;
    }

    //aplicación
    private void ApplyPowerUp(float value)
    {
        switch (selectedPowerUp)
        {
            case PowerUpType.Heal:
                playerStats.Heal(value);
                messageText.text = $"Curado +{value}. Vida actual: {playerStats.CurrentHealth}";
                break;

            case PowerUpType.SpeedBoost:
                playerStats.SetSpeedMultiplier(value);
                messageText.text = $"Velocidad actual: {playerStats.CurrentSpeed}";
                break;

            case PowerUpType.Shield:
                playerStats.SetShield(true);
                messageText.text = "Escudo activado.";
                break;

            case PowerUpType.DamageBoost:
                messageText.text = $"Damage Boost registrado: {value}";
                break;
        }
    }
}