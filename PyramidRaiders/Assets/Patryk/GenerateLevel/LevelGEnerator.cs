using System.Collections.Generic;
using UnityEngine;



public class RoomManager : MonoBehaviour
{
    [SerializeField] private List<RoomType> roomTypes; // Lista typ�w pomieszcze�
    [SerializeField] private int totalRooms = 10; // Ca�kowita liczba pomieszcze� do wygenerowania
    [SerializeField] private GameObject startRoomPrefab; // Prefab startowego pomieszczenia
    [SerializeField] private GameObject endRoomPrefab; // Prefab koncowego pomieszczenia
    [SerializeField] private GameObject deadendRoomPrefab; // Prefab koncowegokorytazakolizji
                                                           // pomieszczenia
    private List<GameObject> spawnedRooms = new List<GameObject>(); // Lista wygenerowanych pomieszcze�
    private Queue<Transform> exitsQueue = new Queue<Transform>(); // Kolejka wyj�� do obs�u�enia
    private List<GameObject> deadendRooms = new List<GameObject>();

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

        // Generowanie pozosta�ych pomieszcze�
        for (int i = 0; i < totalRooms; i++)
        {
            if (exitsQueue.Count == 0) break;

            Transform exit = exitsQueue.Dequeue();
            GenerateRoomAtExit(exit);
        }
        PlaceEndRoom();
        // Sprawdzenie minimalnych wymaga�
        EnsureMinimumRooms();
    }

    private void GenerateRoomAtExit(Transform exit)
    {
        // Losowy typ pokoju
        RoomType randomRoom = roomTypes[Random.Range(0, roomTypes.Count)];
        Debug.Log($"Generowanie pokoju typu: {randomRoom.typeName}");

        // Tworzenie pokoju
        GameObject room = Instantiate(randomRoom.prefab, exit.position, exit.rotation);

        // Detekcja kolizji
        if (IsRoomColliding(room))
        {
            Debug.Log($"Kolizja wykryta dla pokoju: {randomRoom.typeName}. Niszczenie pokoju.");
            Destroy(room);
            GameObject deadend = Instantiate(deadendRoomPrefab, exit.position, exit.rotation);
            deadendRooms.Add(deadend); // Dodajemy deadend do listy
            return;
        }


        // Dodanie wyj�� nowego pokoju
        RegisterRoomExits(room);
        spawnedRooms.Add(room);
        Debug.Log($"Pok�j {randomRoom.typeName} wygenerowany poprawnie.");
    }
    private bool IsRoomColliding(GameObject room)
    {
        BoxCollider roomCollider = room.GetComponent<BoxCollider>();

        if (roomCollider == null)
        {
            Debug.LogError($"Room {room.name} nie posiada BoxCollidera! Sprawd� prefab.");
            return true; // Je�li brak BoxCollidera, traktujemy to jako kolizj�
        }

        Collider[] overlappingColliders = Physics.OverlapBox(
            roomCollider.bounds.center,
            roomCollider.bounds.extents,
            room.transform.rotation
        );

        foreach (var collider in overlappingColliders)
        {
            if (collider.gameObject == room)
                continue; // Ignoruj obecny pok�j

            // Sprawdzaj tylko obiekty z tagiem "Room"
            if (collider.CompareTag("Room"))
            {
                Debug.Log($"Kolizja wykryta: {room.name} z {collider.gameObject.name}");
                return true; // Wykryto kolizj� z innym pokojem
            }
        }

        return false; // Brak kolizji z obiektami oznaczonymi tagiem "Room"
    }

    private void RegisterRoomExits(GameObject room)
    {
        foreach (Transform child in room.transform)
        {
            if (child.CompareTag("Exit"))
            {
                Debug.Log($"Wyj�cie dodane do kolejki: {child.name}");
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
    private void PlaceEndRoom()
    {
        if (exitsQueue.Count == 0)
        {
            if (deadendRooms.Count == 0)
            {
                Debug.LogWarning("Brak dost�pnych wyj�� ani deadend�w do umieszczenia pokoju ko�cowego.");
                return;
            }

            // Wybieramy ostatni deadend
            GameObject lastDeadend = deadendRooms[deadendRooms.Count - 1];
            Vector3 position = lastDeadend.transform.position;
            Quaternion rotation = lastDeadend.transform.rotation;

            // Tworzymy �cian� ko�cow� tu� przed deadendem
            position -= lastDeadend.transform.forward * 2; // Odsu� collider od deadendu
            lastDeadend.SetActive(false);
            GameObject endWall = Instantiate(endRoomPrefab, position, rotation);
            Debug.Log("Pok�j ko�cowy umieszczony przed ostatnim deadendem.");
            spawnedRooms.Add(endWall);

            return;
        }

        Transform exit = exitsQueue.Dequeue();

        // Tworzenie pokoju ko�cowego
        GameObject endRoom = Instantiate(endRoomPrefab, exit.position, exit.rotation);

        // Sprawdzenie kolizji
        if (IsRoomColliding(endRoom))
        {
            Debug.Log($"Kolizja wykryta dla pokoju ko�cowego. Niszczenie pokoju.");
            Destroy(endRoom);
            Instantiate(deadendRoomPrefab, exit.position, exit.rotation);
        }
        else
        {
            Debug.Log("Pok�j ko�cowy wygenerowany poprawnie.");
            spawnedRooms.Add(endRoom);
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