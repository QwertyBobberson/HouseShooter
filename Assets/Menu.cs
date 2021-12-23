using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] Button singlePlayerButton;
    [SerializeField] Button multiPlayerButton;
    [SerializeField] Button quitButton;

    void Start ()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        singlePlayerButton.onClick.AddListener(SinglePlayerMode);
        multiPlayerButton.onClick.AddListener(MultiPlayerMode);
        quitButton.onClick.AddListener(QuitGame);
    }
	

    void SinglePlayerMode()
    {
        SceneManager.LoadScene("277ZombieMode", LoadSceneMode.Single);
        return;
    }
    void MultiPlayerMode()
    {
        SceneManager.LoadScene("277", LoadSceneMode.Single);
        return;
    }
    void QuitGame()
    {
        Application.Quit();
    }

}
