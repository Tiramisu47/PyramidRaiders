using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic instance;

    void Awake()
    {
        // Sprawd�, czy istnieje ju� instancja
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // Usu� duplikaty
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject); // Nie niszcz obiektu przy zmianie sceny
    }
}
