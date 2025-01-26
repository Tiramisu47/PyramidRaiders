using UnityEngine;

public class RotatePrefab : MonoBehaviour
{
    // Szybko�� obrotu
    [SerializeField]
    private float rotationSpeed = 50f;

    // O� obrotu
    [SerializeField]
    private Vector3 rotationAxis = Vector3.up;

    void Update()
    {
        // Obracanie obiektu wok� jego lokalnej osi
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
    }
}
