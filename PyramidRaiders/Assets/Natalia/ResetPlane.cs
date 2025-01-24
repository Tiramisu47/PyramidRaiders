using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlane : MonoBehaviour
{
    public Transform resetPoint; // gdzie bedzie spawnowal sie gracz

    public void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            player.transform.position = resetPoint.position;
            Rigidbody rb = player.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }
}
