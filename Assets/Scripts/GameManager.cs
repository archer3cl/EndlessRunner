using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public static GameManager instance = null;
    public Transform platformGenerator;
    public PlayerController player;
    public DeathMenu deathMenu;

    private Vector3 platformGeneratorStartPoint;
    private Vector3 playerStartPoint;
    private PlatformDestroyer[] platformList;
    private ScoreManager scoreManager;
    private PauseMenu pauseButton;
    void Awake() {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }        
    }

    // Use this for initialization
    void Start () {
        platformGeneratorStartPoint = platformGenerator.position;
        playerStartPoint = player.transform.position;
        scoreManager = FindObjectOfType<ScoreManager>();
        pauseButton = FindObjectOfType<PauseMenu>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void EndGame() {
        pauseButton.gameObject.SetActive(false);
        scoreManager.scoreIncreasing = false;
        player.gameObject.SetActive(false);
        deathMenu.gameObject.SetActive(true);
    }

    public void ResetGame() {
        deathMenu.gameObject.SetActive(false);
        platformList = FindObjectsOfType<PlatformDestroyer>();
        foreach (var platform in platformList) {
            platform.gameObject.SetActive(false);
        }
        player.transform.position = playerStartPoint;
        platformGenerator.position = platformGeneratorStartPoint;
        player.gameObject.SetActive(true);
        scoreManager.scoreCount = 0;
        scoreManager.scoreIncreasing = true;
        pauseButton.gameObject.SetActive(true);
    }
   
}
