using UnityEngine;

public class FlameTrap : MonoBehaviour
{
    [SerializeField] private ParticleSystem flameParticleSystem; // Referencja do systemu cz¹steczek
    [SerializeField] private float flameDuration = 5f; // Czas trwania ognia
    private bool isActivated = false; // Czy pu³apka jest aktywna

    private void Start()
    {
        // Upewniamy siê, ¿e ogieñ jest wy³¹czony na pocz¹tku
        if (flameParticleSystem != null)
        {
            flameParticleSystem.Stop();
        }
        else
        {
            Debug.LogWarning("Nie przypisano systemu cz¹steczek do FlameTrap!");
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
            flameParticleSystem.Play(); // W³¹cz system cz¹steczek
            isActivated = true;
            Debug.Log("Ogieñ zosta³ aktywowany!");

            // Dezaktywacja ognia po okreœlonym czasie
            Invoke(nameof(DeactivateFlame), flameDuration);
            flameParticleSystem.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Nie przypisano systemu cz¹steczek w FlameTrap!");
        }
    }

    private void DeactivateFlame()
    {
        if (flameParticleSystem != null)
        {
            flameParticleSystem.Stop(); // Wy³¹cz system cz¹steczek
            Debug.Log("Ogieñ zosta³ wy³¹czony!");
            flameParticleSystem.gameObject.SetActive(false);
        }
        isActivated = false; // Reset pu³apki
    }
}
