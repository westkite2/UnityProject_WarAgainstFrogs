using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject PauseUI;

    AudioSource Audiosource;
    public AudioClip AC_click;

    private void Start()
    {
        this.Audiosource = GetComponent<AudioSource>();
    }
    public void OnClickStartButton()
    {
        Audiosource.PlayOneShot(AC_click);
        Time.timeScale = 1f;
        SceneManager.LoadScene("WarAgainstFrogs");
    }
    public void OnClickRetryButton()
    {
        Audiosource.PlayOneShot(AC_click);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OnClickExitButton()
    {
        Audiosource.PlayOneShot(AC_click);

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    public void OnClickPauseButton()
    {
        Audiosource.PlayOneShot(AC_click);
        Time.timeScale = 0f;
        PauseUI.SetActive(true);
        
    }
    public void OnClickKeepPlayingButton()
    {
        Audiosource.PlayOneShot(AC_click);
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
    }
    public void OnClickRestartButton()
    {
        Audiosource.PlayOneShot(AC_click);
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OnClickGoHomeButton()
    {
        Audiosource.PlayOneShot(AC_click);
        Time.timeScale = 1f;
        SceneManager.LoadScene("TitleScene");
    }

}
