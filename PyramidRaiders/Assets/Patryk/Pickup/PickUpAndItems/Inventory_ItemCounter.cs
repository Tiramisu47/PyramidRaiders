using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory_ItemCounter : MonoBehaviour
{
    [SerializeField] private List<ItemsSO> items = new(); // Lista przedmiot�w
    [SerializeField] private TextMeshProUGUI valueText; // Tekst w UI
                                                        // Dodaj przedmiot do listy

    int x = 0;
    int y = 0;

    public void AddItem(ItemsSO item)
    {
        
            items.Add(item);
            Debug.Log($"Dodano przedmiot: {item.itemName}");
        UpdateValueUI();

    }

    // Usu� przedmiot z listy
    public void RemoveItem(ItemsSO item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            Debug.Log($"Usuni�to przedmiot: {item.itemName}");
            UpdateValueUI();
        }
        else
        {
            Debug.Log($"Przedmiot {item.itemName} nie istnieje w ekwipunku.");
        }
    }
    private void UpdateValueUI()
    {
        foreach (var item in items)
        {
            x += item.value;
        }
        valueText.text = x.ToString() + "$";
        y = items.Count;
    }
    // Wy�wietl wszystkie przedmioty


    public void SaveInventoryData()
    {
        EndSceneManager.TotalValue = x; // Przypisanie ca�kowitej warto�ci
        EndSceneManager.TotalCount = y; // Przypisanie liczby przedmiot�w
    }
}
