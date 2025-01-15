using System.Collections.Generic;
using UnityEngine;



public class RoomManager : MonoBehaviour
{
    [SerializeField] private List<RoomType> roomTypes; // Lista typów pomieszczeñ
    [SerializeField] private int totalRooms = 10; // Ca³kowita liczba pomieszczeñ do wygenerowania
    [SerializeField] private GameObject startRoomPrefab; // Prefab startowego pomieszczenia

    private List<GameObject> spawnedRooms = new List<GameObject>(); // Lista wygenerowanych pomieszczeñ
    private Queue<Transform> exitsQueue = new Queue<Transform>(); // Kolejka wyjœæ do obs³u¿enia

    private void Start()
    {
        GenerateLevel();
    }
    public void GenerateLevel()
    {
        ClearLevel();

        // Tworzenie startowego pokoju
        GameObject startRoom = Instantiate(startRoomPrefab, Vector3.zero, Quaternion.identity);
        RegisterRoomExits(startRoom);

        // Generowanie pozosta³ych pomieszczeñ
        for (int i = 0; i < totalRooms; i++)
        {
            if (exitsQueue.Count == 0) break;

            Transform exit = exitsQueue.Dequeue();
            GenerateRoomAtExit(exit);
        }

        // Sprawdzenie minimalnych wymagañ
        EnsureMinimumRooms();
    }

    private void GenerateRoomAtExit(Transform exit)
    {
        RoomType randomRoom = roomTypes[Random.Range(0, roomTypes.Count)];
        GameObject room = Instantiate(randomRoom.prefab, exit.position, exit.rotation);

        // Detekcja kolizji
        if (IsRoomColliding(room))
        {
            Destroy(room);
            return;
        }

        RegisterRoomExits(room);
        spawnedRooms.Add(room);
    }

    private bool IsRoomColliding(GameObject room)
    {
        Collider[] colliders = Physics.OverlapBox(room.transform.position, room.transform.localScale / 2, room.transform.rotation);
        foreach (var collider in colliders)
        {
            if (!spawnedRooms.Contains(collider.gameObject))
            {
                return true;
            }
        }
        return false;
    }

    private void RegisterRoomExits(GameObject room)
    {
        foreach (Transform child in room.transform)
        {
            if (child.CompareTag("Exit"))
            {
                exitsQueue.Enqueue(child);
            }
        }
        spawnedRooms.Add(room);
    }

    private void EnsureMinimumRooms()
    {
        foreach (var roomType in roomTypes)
        {
            int count = spawnedRooms.FindAll(room => room.name.Contains(roomType.typeName)).Count;
            while (count < roomType.minCount)
            {
                if (exitsQueue.Count == 0) break;

                Transform exit = exitsQueue.Dequeue();
                GameObject room = Instantiate(roomType.prefab, exit.position, exit.rotation);

                if (!IsRoomColliding(room))
                {
                    RegisterRoomExits(room);
                    count++;
                }
                else
                {
                    Destroy(room);
                }
            }
        }
    }

    private void ClearLevel()
    {
        foreach (var room in spawnedRooms)
        {
            Destroy(room);
        }
        spawnedRooms.Clear();
        exitsQueue.Clear();
    }
}
