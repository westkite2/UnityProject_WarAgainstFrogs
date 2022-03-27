using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyZoneScript : MonoBehaviour
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
        Debug.Log("frog entered fly zone");
        FrogController.isCrawling = false;
        FrogController.isFlying = true;
    }
}
