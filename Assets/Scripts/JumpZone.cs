using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpZone : MonoBehaviour
{
    public GameObject Frog;
    public GameObject Ship;
    private FrogController FrogControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        FrogControllerScript = Frog.GetComponent<FrogController>();        
    }

    private void OnTriggerEnter(Collider other)
    {
        FrogControllerScript.isSwimming = false; 
        FrogControllerScript.isJumping = true;

        FrogControllerScript.startTime = Time.time;
        FrogControllerScript.jumpPos = Frog.transform.position;
        FrogControllerScript.landPos = new Vector3(Frog.transform.position.x, 0.3f, Ship.transform.position.z);
    }


}
