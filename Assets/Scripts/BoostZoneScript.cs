using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostZoneScript : MonoBehaviour
{
    private FrogController FrogController;
    public GameObject Frog;

    // Start is called before the first frame update
    void Start()
    {
        FrogController = Frog.GetComponent<FrogController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("frog entered boost zone");
        FrogController.isFlying = false;
        FrogController.isBoosting = true;
        
    }
}
