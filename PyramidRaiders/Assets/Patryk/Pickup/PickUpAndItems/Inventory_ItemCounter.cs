using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory_ItemCounter : MonoBehaviour
{
    [SerializeField] private List<ItemsSO> items = new(); // Lista przedmiotów
    [SerializeField] private TextMeshProUGUI valueText; // Tekst w UI
    // Dodaj przedmiot do listy
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
        int x = 0;
        foreach (var item in items)
        {
            x += item.value;
        }
        valueText.text = x.ToString() + "$";
    }
    // Wyœwietl wszystkie przedmioty
    public void DisplayItems()
    {
        Debug.Log("Lista przedmiotów w ekwipunku:");
        foreach (var item in items)
        {
            Debug.Log($"- {item.itemName}: {item.description}");
        }
    }
}
