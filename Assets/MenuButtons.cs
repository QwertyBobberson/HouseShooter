using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] Button ResumeButton;
    [SerializeField] Button mainMenuButton;

	void Start ()
    {
        ResumeButton.onClick.AddListener(Resume);
        mainMenuButton.onClick.AddListener(GoToMainMenu);
	}
	void Resume()
    {
        PauseMenu.isPaused = false;
        Time.timeScale = 1;
        SceneManager.UnloadSceneAsync("Menu");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
	
    void GoToMainMenu()
    {
        PauseMenu.isPaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("MainScreen", LoadSceneMode.Single);

    }
}
