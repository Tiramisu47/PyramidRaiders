using UnityEngine;

public class RotatePrefab : MonoBehaviour
{
    // Szybkość obrotu
    [SerializeField]
    private float rotationSpeed = 50f;

    // Oś obrotu
    [SerializeField]
    private Vector3 rotationAxis = Vector3.up;

    void Update()
    {
        // Obracanie obiektu wokół jego lokalnej osi
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
    }
}
