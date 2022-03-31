using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogController : MonoBehaviour
{
    private GameObject Guts;
    private Rigidbody Rigid;
    private GameManager GameManager;
    private Animator Anim;

    private float attackTimer;
    private int waitingTime;

    //Flags
    public bool isCrawling = true;
    public bool isFlying = false;
    public bool isBoosting = false;
    public bool isLanding = false;
    private bool isAttacking = false;
    private bool isSmashed = false;

    // Start is called before the first frame update
    void Start()
    {
        Anim = this.GetComponent<Animator>();
        Rigid = gameObject.GetComponent<Rigidbody>();
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Guts = this.transform.GetChild(5).gameObject;
        Guts.SetActive(false);

        attackTimer = 0.0f;
        waitingTime = 1;

        Physics.IgnoreLayerCollision(3, 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (isSmashed)
        {
            Smashed();
        }
        else if (isLanding)
        {
            Land();
        }
        else if (isAttacking)
        {
            Attack();
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
        if(isSmashed == false)
        {
            GameManager.score += 10;
            isSmashed = true;
        }
    }

    private void Crawl()
    {
        Anim.SetBool("Crawl", true);
        transform.Translate(0, 0, 0.005f);
    }
    private void Fly()
    {
        Anim.SetBool("Fly", true);
        Anim.SetBool("Crawl", false);
        transform.Translate(0, 0.02f, 0.008f);
    }
    private void Boost()
    {
        Anim.SetBool("Boost", true);
        transform.Translate(0, 0, 0.05f);
    }
    private void Land()
    {
        Anim.SetBool("Land", true);
        transform.position = transform.position;
        isAttacking = true;
        isLanding = false;
        
    }
    private void Attack()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer > waitingTime)
        {
            Debug.Log("attack!");
            Anim.SetTrigger("Attack");
            StartCoroutine("RedFlick");
            attackTimer = 0;
        }
    }
    IEnumerator RedFlick()
    {
        yield return new WaitForSeconds(0.3f);
        GameManager.Damage.SetActive(true);
        GameManager.hp -= 20;
        yield return new WaitForSeconds(0.1f);
        GameManager.Damage.SetActive(false);
    }

    private void Smashed()
    {
        isCrawling = false;
        isFlying = false;
        isBoosting = false;
        isLanding = false;
        isAttacking = false;
        Anim.SetBool("Smashed", true);
        Guts.SetActive(true);
        Rigid.constraints = RigidbodyConstraints.FreezeRotation;
        Rigid.useGravity = true;
        StartCoroutine("DisableFrog");
    }
    IEnumerator DisableFrog()
    {
        yield return new WaitForSeconds(1f);
        this.gameObject.SetActive(false);
        Guts.SetActive(false);
        Rigid.constraints = RigidbodyConstraints.None;
        Rigid.useGravity = false;
        Anim.SetBool("Fly", false);
        Anim.SetBool("Boost", false);
        Anim.SetBool("Land", false);
        Anim.ResetTrigger("Attack");
        Anim.SetBool("Smashed", false);
        isSmashed = false;
        isCrawling = true;
        this.gameObject.transform.position =
                new Vector3(Random.Range(-0.8f, 0.8f),
                            Random.Range(0.05f, 0.05f),
                            Random.Range(-1.7f, -1.3f));

    }
}
