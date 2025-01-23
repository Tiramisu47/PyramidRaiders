using UnityEngine;

public class RopeTrigger : MonoBehaviour
{
    // Referencja do miotacza ognia
    [SerializeField]
    private FlameThrower flameThrower;

    private void OnTriggerEnter(Collider other)
    {
        // Sprawdzenie, czy obiekt, kt�ry dotkn�� linki, to gracz
        if (other.CompareTag("Player"))
        {
            Debug.Log("Gracz dotkn�� linki! Uruchamianie miotacza ognia...");

            // Wywo�anie akcji miotacza ognia
            if (flameThrower != null)
            {
                flameThrower.ActivateFlame();
            }
            else
            {
                Debug.LogWarning("Miotacz ognia nie jest przypisany do linki!");
            }
        }
    }
}
