using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject PauseUI;
    public void OnClickStartButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("WarAgainstFrogs");
    }
    public void OnClickRetryButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OnClickExitButton()
    {
        Debug.Log("Clicked Exit Button");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    public void OnClickPauseButton()
    {
        Time.timeScale = 0f;
        PauseUI.SetActive(true);
        
    }
    public void OnClickKeepPlayingButton()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
    }
    public void OnClickRestartButton()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OnClickGoHomeButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("TitleScene");
    }
}
