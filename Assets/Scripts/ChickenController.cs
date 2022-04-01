using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenController : MonoBehaviour
{
    public GameManager GameManager;
    private Animator Anim;
    public bool isRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
        Anim = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isRunning)
        {
            transform.Translate(0, 0, 0.05f);
        }
        else
        {
            transform.Translate(0, 0, 0.15f);
        }

    }
    private void OnMouseDown()
    {
        this.transform.GetChild(5).gameObject.SetActive(false);
        GameManager.hp = 100;
        Anim.SetBool("Run", true);
        isRunning = true;
    }
}
