using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string LevelToLoad;

    public GameObject settingWindow;
    public void StartGame()
    {
        SceneManager.LoadScene(LevelToLoad);
    }

    public void SettingButton()
    {
        settingWindow.SetActive(true);
    }

    public void CloseSettingsWindow()
    {
        settingWindow.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
