using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class wcisnijMnie : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("uruchomiono przycisk, koniec gry!");
            SceneManager.LoadScene("EndScene");
        }
        
    }
}
