using UnityEngine;

public class CurrentSceneManager : MonoBehaviour
{
    public bool playerIsPresent = false;

    public static CurrentSceneManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Plus d'une instance de CurrentSceneManager");
            return;
        }

        instance = this;
    }
}
