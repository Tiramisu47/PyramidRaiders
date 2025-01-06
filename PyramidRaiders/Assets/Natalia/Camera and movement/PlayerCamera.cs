using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float sensX, sensY; // czulosc

    public Transform orientation;

    float xRotation, yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // zablokowanie kursora na srodku ekranu
        Cursor.visible = false; // niewidzialny kursor

    }
    private void Update()
    {
        // mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX; xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // zasieg patrzenia w gore i w dol

        // obrot - kamera i orientacja (czyli w ktora strone kieruje sie gracz)
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0); // obrot pola widzenia gracza w osi Y
    }
}
