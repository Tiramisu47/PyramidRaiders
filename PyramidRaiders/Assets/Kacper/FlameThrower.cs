using UnityEngine;

public class FlameThrower : MonoBehaviour
{
    // Prefab systemu cz¹steczek ognia
    [SerializeField]
    private GameObject flamePrefab;

    // Pozycja, z której ma siê pojawiæ ogieñ
    [SerializeField]
    private Transform flameSpawnPoint;

    // Czas trwania dzia³ania miotacza ognia
    [SerializeField]
    private float flameDuration = 3f;

    // Referencja do instancji ognia
    private GameObject activeFlame;

    // Aktywacja miotacza ognia na okreœlony czas
    public void ActivateFlame()
    {
        if (flamePrefab != null && flameSpawnPoint != null)
        {
            Debug.Log($"Tworzenie efektu cz¹steczkowego: {flamePrefab.name} w pozycji {flameSpawnPoint.position}");

            // Tworzenie instancji ognia
            activeFlame = Instantiate(flamePrefab, flameSpawnPoint.position, flameSpawnPoint.rotation);

            Debug.Log("Efekt cz¹steczkowy zosta³ wygenerowany!");
        }
        else
        {
            if (flamePrefab == null)
            {
                Debug.LogWarning("Prefab ognia nie jest przypisany!");
            }
            if (flameSpawnPoint == null)
            {
                Debug.LogWarning("Punkt generowania ognia nie jest ustawiony!");
            }
        }
    }


    // Wy³¹czanie miotacza ognia
    private void DeactivateFlame()
    {
        if (activeFlame != null)
        {
            Destroy(activeFlame);
            Debug.Log("Miotacz ognia zosta³ dezaktywowany!");
        }
    }
}
