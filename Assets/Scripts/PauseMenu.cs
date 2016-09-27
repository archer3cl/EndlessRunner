using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    public GameObject pauseMenu;
    public void PauseGame() {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ResumeGame() {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        gameObject.SetActive(true);
    }

    public void QuitToMainMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartGame() {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        gameObject.SetActive(true);
        GameManager.instance.ResetGame();
    }
}
