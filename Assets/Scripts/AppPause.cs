using UnityEngine;
using System.Collections;

public class AppPause : MonoBehaviour {
    public PauseMenu pauseButton;
    private bool isPaused = false;

    void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }

    void OnGUI() {
        if (isPaused) {
            pauseButton.PauseGame();
        }
            
    }

    //void OnApplicationFocus(bool focusStatus) {
    //    isPaused = focusStatus;
    //}

    void OnApplicationPause(bool pauseStatus) {
        isPaused = pauseStatus;
    }
}
