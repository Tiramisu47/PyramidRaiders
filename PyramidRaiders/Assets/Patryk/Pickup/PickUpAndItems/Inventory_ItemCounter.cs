using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory_ItemCounter : MonoBehaviour
{
    [SerializeField] private List<ItemsSO> items = new(); // Lista przedmiotów
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

    // Usuñ przedmiot z listy
    public void RemoveItem(ItemsSO item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            Debug.Log($"Usuniêto przedmiot: {item.itemName}");
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
    // Wyœwietl wszystkie przedmioty


    public void SaveInventoryData()
    {
        EndSceneManager.TotalValue = x; // Przypisanie ca³kowitej wartoœci
        EndSceneManager.TotalCount = y; // Przypisanie liczby przedmiotów
    }
}
