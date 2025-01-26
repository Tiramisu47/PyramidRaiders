using UnityEngine;

public class RotatePrefab : MonoBehaviour
{
    // Szybkoœæ obrotu
    [SerializeField]
    private float rotationSpeed = 50f;

    // Oœ obrotu
    [SerializeField]
    private Vector3 rotationAxis = Vector3.up;

    void Update()
    {
        // Obracanie obiektu wokó³ jego lokalnej osi
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
    }
}
