using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "ItemsObject/Recipe")]
public class CraftingRecipe : ScriptableObject
{
    public ItemsSO resultItem;       // Przedmiot, kt�ry powstanie
    public ItemsSO[] ingredients;    // Sk�adniki potrzebne do stworzenia przedmiotu
    public int[] ingredientCounts; // Ilo�� ka�dego sk�adnika (odpowiada `ingredients`)
}
