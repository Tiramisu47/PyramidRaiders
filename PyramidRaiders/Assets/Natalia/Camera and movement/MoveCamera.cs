using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosition;
    void Update() // kamera bedzie poruszac sie wraz z graczem
    {
        transform.position = cameraPosition.position;
    }
}
