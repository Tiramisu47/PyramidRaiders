using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [System.Serializable]
    public class SpawnLocation
    {
        public Transform location;          // Miejsce spawnowania
        public float spawnChance;           // Szansa na spawn w tej lokacji
        public ItemsSO[] itemsForLocation; // Lista przedmiotów dla tej lokacji
    }

    [SerializeField] private SpawnLocation[] spawnLocations; // Tablica wszystkich lokacji spawnowania

    private void Start()
    {
        // Sprawdzamy ka¿d¹ lokacjê
        foreach (var spawnLocation in spawnLocations)
        {
            TrySpawnItemAtLocation(spawnLocation);
        }
    }

    private void TrySpawnItemAtLocation(SpawnLocation spawnLocation)
    {
        // Generujemy losow¹ liczbê od 0 do 100
        float randomChance = Random.Range(0f, 100f);

        // Sprawdzamy, czy losowa liczba mieœci siê w zakresie szans
        if (randomChance <= spawnLocation.spawnChance)
        {
            // Losujemy przedmiot z listy przypisanej do tej lokacji
            if (spawnLocation.itemsForLocation.Length > 0)
            {
                int randomItemIndex = Random.Range(0, spawnLocation.itemsForLocation.Length);
                ItemsSO selectedItem = spawnLocation.itemsForLocation[randomItemIndex];

                // Tworzymy instancjê prefabrykatów wybranego przedmiotu
                Instantiate(selectedItem.prefab, spawnLocation.location.position, Quaternion.identity);
                Debug.Log($"Wygenerowano {selectedItem.itemName} w {spawnLocation.location.name}");
            }
            else
            {
                Debug.LogWarning($"Brak przedmiotów przypisanych do lokacji: {spawnLocation.location.name}");
            }
        }
    }
}
