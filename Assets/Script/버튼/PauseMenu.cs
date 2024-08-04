using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuCanvas;
    public GameObject saveMenuCanvas;

    public GameObject loadMenuCanvas;

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(GameIsPaused)
            {
                BackToGame();
            }
            else
            {
                Pause();
            }
        }
    }

    public void BackToGame()
    {
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Save()
    {
        saveMenuCanvas.SetActive(true);
        loadMenuCanvas.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Load()
    {
        loadMenuCanvas.SetActive(true);
        saveMenuCanvas.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void BackToMenu()
    {
        pauseMenuCanvas.SetActive(true);
        saveMenuCanvas.SetActive(false);
        loadMenuCanvas.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void ToSettingMenu()
    {
        Debug.Log("아직 미구현입니다...");
    }

    public void ToMain()
    {
        Debug.Log("아직 미구현입니다...");
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartScene");
    }

    public void QuitGame()
    {
        Debug.Log("아직 미구현입니다...");
        Application.Quit();
    }
}
