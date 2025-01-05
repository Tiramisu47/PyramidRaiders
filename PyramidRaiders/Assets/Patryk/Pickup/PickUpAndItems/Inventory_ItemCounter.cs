using System.Collections.Generic;
using UnityEngine;

public class Inventory_ItemCounter : MonoBehaviour
{
    [SerializeField] private List<ItemsSO> items = new(); // Lista przedmiotów

    // Dodaj przedmiot do listy
    public void AddItem(ItemsSO item)
    {
        if (!items.Contains(item))
        {
            items.Add(item);
            Debug.Log($"Dodano przedmiot: {item.itemName}");
        }
        else
        {
            Debug.Log($"Przedmiot {item.itemName} ju¿ istnieje w ekwipunku.");
        }
    }

    // Usuñ przedmiot z listy
    public void RemoveItem(ItemsSO item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            Debug.Log($"Usuniêto przedmiot: {item.itemName}");
        }
        else
        {
            Debug.Log($"Przedmiot {item.itemName} nie istnieje w ekwipunku.");
        }
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
