using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [System.Serializable]
    public class SpawnLocation
    {
        public Transform location;          // Miejsce spawnowania
        public float spawnChance;           // Szansa na spawn w tej lokacji
        public ItemsSO[] itemsForLocation; // Lista przedmiot�w dla tej lokacji
    }

    [SerializeField] private SpawnLocation[] spawnLocations; // Tablica wszystkich lokacji spawnowania

    private void Start()
    {
        // Sprawdzamy ka�d� lokacj�
        foreach (var spawnLocation in spawnLocations)
        {
            TrySpawnItemAtLocation(spawnLocation);
        }
    }

    private void TrySpawnItemAtLocation(SpawnLocation spawnLocation)
    {
        // Generujemy losow� liczb� od 0 do 100
        float randomChance = Random.Range(0f, 100f);

        // Sprawdzamy, czy losowa liczba mie�ci si� w zakresie szans
        if (randomChance <= spawnLocation.spawnChance)
        {
            // Losujemy przedmiot z listy przypisanej do tej lokacji
            if (spawnLocation.itemsForLocation.Length > 0)
            {
                int randomItemIndex = Random.Range(0, spawnLocation.itemsForLocation.Length);
                ItemsSO selectedItem = spawnLocation.itemsForLocation[randomItemIndex];

                // Tworzymy instancj� prefabrykat�w wybranego przedmiotu
                Instantiate(selectedItem.prefab, spawnLocation.location.position, Quaternion.identity);
                Debug.Log($"Wygenerowano {selectedItem.itemName} w {spawnLocation.location.name}");
            }
            else
            {
                Debug.LogWarning($"Brak przedmiot�w przypisanych do lokacji: {spawnLocation.location.name}");
            }
        }
    }
}
