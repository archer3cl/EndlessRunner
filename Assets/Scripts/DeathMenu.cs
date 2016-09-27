using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {

    public void QuitToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartGame() {
        GameManager.instance.ResetGame();
    }
}
