using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{

    public GameObject Frog;
    FrogController FrogControllerScript;


    // Start is called before the first frame update
    void Start()
    {
        FrogControllerScript = Frog.GetComponent<FrogController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        Debug.Log("entered ship");
        
        FrogControllerScript.isAttacking = true;
        FrogControllerScript.isJumping = false;
    }

}
