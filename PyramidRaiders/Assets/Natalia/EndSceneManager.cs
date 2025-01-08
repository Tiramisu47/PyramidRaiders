using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndSceneManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI totalValueText;  // Tekst dla warto�ci
    [SerializeField] private TextMeshProUGUI totalCountText;  // Tekst dla ilo�ci
    public static int TotalValue = 0;
    public static int TotalCount = 0;
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Wy�wietl informacje o wynikach gry na ekranie ko�cowym
        DisplayResults();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("DEMO");
    }

    public void MainMenu()
    {
        Debug.Log("brak dost�pu");
        //SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    private void DisplayResults()
    {
            // Wy�wietl dane na ekranie ko�cowym
            totalValueText.text = $"Zdobyta warto��: {TotalValue}$";
            totalCountText.text = $"Ilo�� przedmiot�w: {TotalCount}";
    }
}
