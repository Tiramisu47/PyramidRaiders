using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Continue()
    {
        Debug.Log("brak dost�pu");
        // kiedys sie zrobi
    }

    public void Settings()
    {
        Debug.Log("brak dost�pu");
        // to tez kiedys sie zrobi
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
