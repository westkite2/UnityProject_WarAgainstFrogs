using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{

    public GameObject frog;
    FrogController FrogControllerScript;


    // Start is called before the first frame update
    void Start()
    {
        FrogControllerScript = frog.GetComponent<FrogController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        Debug.Log("entered ship");
        
        FrogControllerScript.isAttacking = true;
        FrogControllerScript.isJumping = false;
        


    }

}
