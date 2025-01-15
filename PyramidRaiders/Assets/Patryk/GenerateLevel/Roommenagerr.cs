using UnityEngine;

[CreateAssetMenu(fileName = "NewRoomType", menuName = "LevelGeneration/RoomType", order = 1)]
public class RoomType : ScriptableObject
{
    public string typeName; // Nazwa typu pomieszczenia (np. Sklep, Skarb)
    public GameObject prefab; // Prefab pomieszczenia
    public int minCount; // Minimalna liczba wyst¹pieñ
}
