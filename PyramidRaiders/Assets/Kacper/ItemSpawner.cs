using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    // Tablica przedmiot�w, kt�re mo�na losowo generowa� (teraz to b�d� instancje ItemData)
    [SerializeField]
    private ItemsSO[] itemsSO;

    // Flaga: Czy generowa� od razu po uruchomieniu?
    [SerializeField]
    private bool spawnOnStart = true;

    // Tablica czterech miejsc, w kt�rych mog� spawnowa� si� przedmioty
    [SerializeField]
    private Transform[] spawnLocations;

    // Tablica szansy na spawnowanie w danym miejscu (suma szans powinna wynosi� 100)
    [SerializeField]
    private int[] spawnChances;

    // Start jest wywo�ywany na pocz�tku
    private void Start()
    {
        if (spawnOnStart)
        {
            SpawnRandomItem();
        }
    }

    // Publiczna metoda do generowania losowego przedmiotu
    public void SpawnRandomItem()
    {
        if (itemsSO.Length == 0)
        {
            Debug.LogWarning("Tablica ItemsSO jest pusta!");
            return;
        }

        if (spawnLocations.Length == 0)
        {
            Debug.LogWarning("Brak miejsc do spawnowania!");
            return;
        }

        if (spawnChances.Length != spawnLocations.Length)
        {
            Debug.LogWarning("Tablica spawnChances nie pasuje do liczby spawnLocations!");
            return;
        }

        // Losowanie indeksu miejsca spawnu na podstawie szans
        int spawnIndex = GetSpawnLocationIndex();
        Vector3 spawnPosition = spawnLocations[spawnIndex].position;

        // Losowanie przedmiotu
        int randomIndex = Random.Range(0, itemsSO.Length);
        ItemsSO selectedItem = itemsSO[randomIndex];

        // Tworzenie wizualnego obiektu w miejscu tego obiektu 3D
        GameObject spawnedItem = Instantiate(selectedItem.prefab, spawnPosition, Quaternion.identity);
        spawnedItem.name = selectedItem.name;

        // Je�li prefab ma komponent pozwalaj�cy przypisa� dane, mo�na tu to obs�u�y�
        IItemDataReceiver dataReceiver = spawnedItem.GetComponent<IItemDataReceiver>();
        if (dataReceiver != null)
        {
            dataReceiver.SetItemData(selectedItem);
        }
    }

    // Funkcja do losowania miejsca spawnu na podstawie szans
    private int GetSpawnLocationIndex()
    {
        int totalChance = 0;
        foreach (int chance in spawnChances)
        {
            totalChance += chance;
        }

        int randomChance = Random.Range(0, totalChance);
        int cumulativeChance = 0;

        for (int i = 0; i < spawnChances.Length; i++)
        {
            cumulativeChance += spawnChances[i];
            if (randomChance < cumulativeChance)
            {
                return i;
            }
        }

        // Je�li co� p�jdzie nie tak, to domy�lnie zwr�ci 0
        return 0;
    }
}

// Interfejs opcjonalny do obs�ugi danych przedmiotu w prefabie
public interface IItemDataReceiver
{
    void SetItemData(ItemsSO itemData);
}
