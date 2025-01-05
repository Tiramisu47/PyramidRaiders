using UnityEngine;

[CreateAssetMenu(fileName = "ItemsSO", menuName = "ItemsObject/ItemsSO")]
public class ItemsSO : ScriptableObject
{
    public string itemName;       // Nazwa przedmiotu
    public Sprite itemIcon;       // Ikona przedmiotu
    public string description;    // Opis przedmiotu
    public int value;             // Wartoœæ przedmiotu
}
