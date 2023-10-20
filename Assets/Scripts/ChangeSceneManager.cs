using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneManager : MonoBehaviour
{
    public void Play()
    {
        // Start the next level based on the recorded previous level index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        // Load the main menu scene
        SceneManager.LoadScene(0);
    }

    public void Retry()
    {
        // Retry the recorded previous level index
        SceneManager.LoadScene(1);
    }

    private void OnEnable()
    {
        // Ensure the cursor is visible and unlocked when this script is enabled
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}