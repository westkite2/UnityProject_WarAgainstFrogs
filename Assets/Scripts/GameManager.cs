using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    AudioSource Audiosource;
    AudioSource Bgm;
    public AudioClip AC_attack;
    public AudioClip AC_chickwalk;
    public AudioClip AC_chickrun;
    public AudioClip AC_frog;
    public AudioClip AC_gameover;
    public AudioClip AC_hit;
    public AudioClip AC_item;

    public GameObject HPbar;
    public GameObject GameOverUI;
    public GameObject PauseUI;
    public GameObject Damage;
    public GameObject Chicken;
    private Image HPfill;
    public int hp;
    public Text ScoreUI;
    public Text EndScoreUI;
    public int score;
    public bool GAMEOVER = false;
    public bool chick = true;

    // Start is called before the first frame update
    void Start()
    {
        this.Audiosource = GetComponent<AudioSource>();
        
        GameOverUI.SetActive(false);
        PauseUI.SetActive(false);
        HPfill = HPbar.transform.GetChild(1).GetComponent<Image>();
        Damage = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
        hp = 100;
        score = 0;
        Bgm = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        HPfill.fillAmount = hp / 100f;
        ScoreUI.text = score.ToString();
        if (hp <= 0)
        {
            GAMEOVER = true;
            EndScoreUI.text = score.ToString();
            GameOverUI.SetActive(true);
            Bgm.Pause();
        }
        if (score > 0 & score % 400 == 0)
        {
            Chicken.SetActive(true);
            if (chick)
            {
                StartCoroutine("ChickSound");
                chick = false;
            }

        }
    }
    IEnumerator ChickSound()
    {
        yield return new WaitForSeconds(0.5f);
        PlaySound("CHICKWALK");
    }

    public void PlaySound(string command)
    {
        switch (command)
        {
            case "ATTACK":
                Audiosource.PlayOneShot(AC_attack);
                break;
            case "CHICKWALK":
                Audiosource.PlayOneShot(AC_chickwalk);
                break;
            case "CHICKRUN":
                Audiosource.PlayOneShot(AC_chickrun);
                break;
            case "FROG":
                Audiosource.PlayOneShot(AC_frog);
                break;
            case "HIT":
                Audiosource.PlayOneShot(AC_hit);
                break;
            case "ITEM":
                Audiosource.PlayOneShot(AC_item);
                break;

        }
    }
}
