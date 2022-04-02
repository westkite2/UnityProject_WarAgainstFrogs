using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenStopZoneScript : MonoBehaviour
{
    public GameObject Chicken;
    private Animator Anim;
    public GameManager GameManager;
    private void Start()
    {
        Anim = Chicken.GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.GetChild(5).gameObject.SetActive(true);
        Anim.SetBool("Run", false);
        GameManager.chick = true;
        other.gameObject.GetComponent<ChickenController>().isRunning = false;
        other.gameObject.SetActive(false);
        other.gameObject.transform.position = new Vector3(-3.5f, 0, 1);
        
        
    }
}
