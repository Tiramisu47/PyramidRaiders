using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndSceneManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI totalValueText;  // Tekst dla wartoœci
    [SerializeField] private TextMeshProUGUI totalCountText;  // Tekst dla iloœci
    public static int TotalValue = 0;
    public static int TotalCount = 0;
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Wyœwietl informacje o wynikach gry na ekranie koñcowym
        DisplayResults();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("DEMO");
    }

    public void MainMenu()
    {
        Debug.Log("brak dostêpu");
        //SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    private void DisplayResults()
    {
            // Wyœwietl dane na ekranie koñcowym
            totalValueText.text = $"Zdobyta wartoœæ: {TotalValue}$";
            totalCountText.text = $"Iloœæ przedmiotów: {TotalCount}";
    }
}
