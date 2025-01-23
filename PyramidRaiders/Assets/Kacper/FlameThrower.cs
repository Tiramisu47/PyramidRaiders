using UnityEngine;

public class FlameThrower : MonoBehaviour
{
    // Prefab systemu cz�steczek ognia
    [SerializeField]
    private GameObject flamePrefab;

    // Pozycja, z kt�rej ma si� pojawi� ogie�
    [SerializeField]
    private Transform flameSpawnPoint;

    // Czas trwania dzia�ania miotacza ognia
    [SerializeField]
    private float flameDuration = 3f;

    // Referencja do instancji ognia
    private GameObject activeFlame;

    // Aktywacja miotacza ognia na okre�lony czas
    public void ActivateFlame()
    {
        if (flamePrefab != null && flameSpawnPoint != null)
        {
            Debug.Log($"Tworzenie efektu cz�steczkowego: {flamePrefab.name} w pozycji {flameSpawnPoint.position}");

            // Tworzenie instancji ognia
            activeFlame = Instantiate(flamePrefab, flameSpawnPoint.position, flameSpawnPoint.rotation);

            Debug.Log("Efekt cz�steczkowy zosta� wygenerowany!");
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


    // Wy��czanie miotacza ognia
    private void DeactivateFlame()
    {
        if (activeFlame != null)
        {
            Destroy(activeFlame);
            Debug.Log("Miotacz ognia zosta� dezaktywowany!");
        }
    }
}
