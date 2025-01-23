using UnityEngine;

public class TrapSpawner : MonoBehaviour
{
    // Prefab pułapki, który będzie generowany
    [SerializeField]
    private GameObject trapPrefab;

    // Prefab linki z BoxColliderem
    [SerializeField]
    private GameObject ropePrefab;

    // Punkty, w których mają pojawić się linki
    [SerializeField]
    private Transform[] ropeSpawnPoints;

    // Szansa na pojawienie się pułapki (0-100)
    [Range(0, 100)]
    [SerializeField]
    private float spawnChance = 50f;

    // Flaga: Czy generować od razu po uruchomieniu?
    [SerializeField]
    private bool spawnOnStart = true;

    // Start jest wywoływany na początku
    private void Start()
    {
        if (spawnOnStart)
        {
            TrySpawnTrapWithRopes();
        }
    }

    // Próba wygenerowania pułapki z linkami
    public void TrySpawnTrapWithRopes()
    {
        // Losowanie liczby od 0 do 100
        float randomValue = Random.Range(0f, 100f);

        // Jeśli wartość losowa jest mniejsza od szansy, generujemy pułapkę
        if (randomValue <= spawnChance)
        {
            SpawnTrapWithRopes();
        }
        else
        {
            Debug.Log($"Pułapka się nie pojawiła. Szansa: {spawnChance}%, wylosowano: {randomValue}");
        }
    }

    // Generowanie pułapki i link
    private void SpawnTrapWithRopes()
    {
        // Generowanie pułapki
        if (trapPrefab != null)
        {
            Instantiate(trapPrefab, transform.position, transform.rotation);
            Debug.Log($"Pułapka została wygenerowana w pozycji {transform.position}");
        }
        else
        {
            Debug.LogWarning("Prefab pułapki nie jest ustawiony!");
        }

        // Generowanie link w wybranych punktach
        if (ropePrefab != null && ropeSpawnPoints.Length > 0)
        {
            foreach (Transform spawnPoint in ropeSpawnPoints)
            {
                if (spawnPoint != null)
                {
                    Instantiate(ropePrefab, spawnPoint.position, spawnPoint.rotation);
                    Debug.Log($"Linka została wygenerowana w pozycji {spawnPoint.position}");
                }
                else
                {
                    Debug.LogWarning("Jeden z punktów generowania linki jest pusty!");
                }
            }
        }
        else if (ropePrefab == null)
        {
            Debug.LogWarning("Prefab linki nie jest ustawiony!");
        }
        else if (ropeSpawnPoints.Length == 0)
        {
            Debug.LogWarning("Nie ustawiono punktów generowania linki!");
        }
    }
}
