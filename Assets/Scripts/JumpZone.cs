using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpZone : MonoBehaviour
{
    public GameObject frog;
    public GameObject ship;
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
        FrogControllerScript.isSwimming = false; 
        FrogControllerScript.isJumping = true;
        FrogControllerScript.startTime = Time.time;
        FrogControllerScript.jumpPos = frog.transform.position;
        FrogControllerScript.landPos = new Vector3(frog.transform.position.x, 0.3f, ship.transform.position.z);
    }


}
