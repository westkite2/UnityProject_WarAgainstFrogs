using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogController : MonoBehaviour
{
    public GameObject Guts;

    private Animator Anim;

    //Flags
    public bool isCrawling = true;
    public bool isFlying = false;
    public bool isBoosting = false;
    private bool isLanding = false;
    private bool isSmashed = false;

    // Start is called before the first frame update
    void Start()
    {
        Anim = this.GetComponent<Animator>();
        Guts = this.transform.GetChild(5).gameObject;
        Guts.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isSmashed)
        {
            Smashed();
        }

    }

    private void FixedUpdate()
    {
        if (isCrawling)
        {
            Crawl();
        }
        else if (isFlying)
        {
            Fly();
        }
        else if (isBoosting)
        {
            Boost();
        }


    }

    private void OnMouseDown()
    {
        Debug.Log("frog touched");
        isSmashed = true;
    }

    private void Crawl()
    {
        transform.Translate(0, 0, 0.005f);
    }
    private void Fly()
    {
        Anim.SetBool("Fly", true);
        transform.Translate(0, 0.03f, 0.01f);
    }
    private void Boost()
    {
        transform.Translate(0, 0, 0.01f);
    }
    private void Smashed()
    {
        isCrawling = false;
        isFlying = false;
        isBoosting = false;

        Anim.SetBool("Smashed", true);
        //Guts.SetActive(true);
        transform.Translate(0, -0.05f, 0);
        
    }



}
