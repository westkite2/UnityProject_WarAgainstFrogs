using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogController : MonoBehaviour
{
    public GameObject frog;
    public GameObject guts;
    private Animator animator;
    private bool smashed = false;

    //Flags
    public bool isSwimming = true;
    public bool isJumping = false;

    //Jump
    public Vector3 jumpPos; //Jump starting position
    public Vector3 landPos; //Jump landing position    
    public float reduceHeight = 1f; //center value of the jump parabola (higher the lower)
    public float journeyTime = 2f; //Duration from jumpPos to landPos (higher the slower)
    public float startTime;

    private void Awake()
    {
        animator = frog.GetComponent<Animator>();

    }

    void Start()
    {
        
    }

    void Update()
    {
        if (isSwimming)
        {
            transform.Translate(0, 0, 0.01f);
        }
        if (isJumping)
        {
            Jump();
        }

    }

    //Custom Functions
    public void Jump()
    {
        animator.SetBool("Jump", true);
        Vector3 center = (jumpPos + landPos) * 0.5F; //gose up by center value
        center -= new Vector3(0, 1f * reduceHeight, 0); //higher y the lower
        Vector3 jumpCenter = jumpPos - center;
        Vector3 landCenter = landPos - center;
        float fracComplete = (Time.time - startTime) / journeyTime;
        transform.position = Vector3.Slerp(jumpCenter, landCenter, fracComplete);
        transform.position += center;
    }
}
