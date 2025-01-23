using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    // Tablica przedmiot�w, kt�re mo�na losowo generowa�
    [SerializeField]
    private ScriptableObject[] itemsSO;

    // Prefab, kt�ry b�dzie reprezentowa� wizualny obiekt (mo�esz podpi�� model 3D)
    [SerializeField]
    private GameObject itemPrefab;

    // Flaga: Czy generowa� od razu po uruchomieniu?
    [SerializeField]
    private bool spawnOnStart = true;

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

        // Losowanie indeksu w tablicy
        int randomIndex = Random.Range(0, itemsSO.Length);
        ScriptableObject selectedItem = itemsSO[randomIndex];

        // Tworzenie wizualnego obiektu w miejscu tego obiektu 3D
        GameObject spawnedItem = Instantiate(itemPrefab, transform.position, Quaternion.identity);
        spawnedItem.name = selectedItem.name;

        // Je�li prefab ma komponent pozwalaj�cy przypisa� dane, mo�na tu to obs�u�y�
        IItemDataReceiver dataReceiver = spawnedItem.GetComponent<IItemDataReceiver>();
        if (dataReceiver != null)
        {
            dataReceiver.SetItemData(selectedItem);
        }
    }
}

// Interfejs opcjonalny do obs�ugi danych przedmiotu w prefabie
public interface IItemDataReceiver
{
    void SetItemData(ScriptableObject itemData);
}
