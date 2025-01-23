using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    // Tablica przedmiotów, które mo¿na losowo generowaæ
    [SerializeField]
    private ScriptableObject[] itemsSO;

    // Prefab, który bêdzie reprezentowa³ wizualny obiekt (mo¿esz podpi¹æ model 3D)
    [SerializeField]
    private GameObject itemPrefab;

    // Flaga: Czy generowaæ od razu po uruchomieniu?
    [SerializeField]
    private bool spawnOnStart = true;

    // Start jest wywo³ywany na pocz¹tku
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

        // Jeœli prefab ma komponent pozwalaj¹cy przypisaæ dane, mo¿na tu to obs³u¿yæ
        IItemDataReceiver dataReceiver = spawnedItem.GetComponent<IItemDataReceiver>();
        if (dataReceiver != null)
        {
            dataReceiver.SetItemData(selectedItem);
        }
    }
}

// Interfejs opcjonalny do obs³ugi danych przedmiotu w prefabie
public interface IItemDataReceiver
{
    void SetItemData(ScriptableObject itemData);
}
