using UnityEngine;

public class ResetPlane : MonoBehaviour
{
    public Transform resetPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Gracz dotkn¹³ obszaru resetu.");
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }

            other.transform.position = resetPoint.position;
        }
    }
}
