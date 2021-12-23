using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
			if (isPaused == false)
			{
				isPaused = true;
				SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
				Time.timeScale = 0;
			}
			else if (isPaused == true)
			{
				isPaused = false;
				SceneManager.UnloadSceneAsync("Menu");
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
				Time.timeScale = 1;
			}
            
        }
    }
}
