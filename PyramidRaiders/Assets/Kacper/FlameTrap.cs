using UnityEngine;

public class FlameTrap : MonoBehaviour
{
    [SerializeField] private ParticleSystem flameParticleSystem; // Referencja do systemu cz�steczek
    [SerializeField] private float flameDuration = 5f; // Czas trwania ognia
    private bool isActivated = false; // Czy pu�apka jest aktywna

    private void Start()
    {
        // Upewniamy si�, �e ogie� jest wy��czony na pocz�tku
        if (flameParticleSystem != null)
        {
            flameParticleSystem.Stop();
        }
        else
        {
            Debug.LogWarning("Nie przypisano systemu cz�steczek do FlameTrap!");
        }
        flameParticleSystem.gameObject.SetActive(false);
    }

    public void ActivateFlame()
    {
        if (isActivated)
        {
            return; // Zapobiega wielokrotnej aktywacji
        }

        if (flameParticleSystem != null)
        {
            flameParticleSystem.Play(); // W��cz system cz�steczek
            isActivated = true;
            Debug.Log("Ogie� zosta� aktywowany!");

            // Dezaktywacja ognia po okre�lonym czasie
            Invoke(nameof(DeactivateFlame), flameDuration);
            flameParticleSystem.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Nie przypisano systemu cz�steczek w FlameTrap!");
        }
    }

    private void DeactivateFlame()
    {
        if (flameParticleSystem != null)
        {
            flameParticleSystem.Stop(); // Wy��cz system cz�steczek
            Debug.Log("Ogie� zosta� wy��czony!");
            flameParticleSystem.gameObject.SetActive(false);
        }
        isActivated = false; // Reset pu�apki
    }
}
