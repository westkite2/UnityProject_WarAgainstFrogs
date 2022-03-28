using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyZoneScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("frog entered fly zone");
        other.gameObject.GetComponent<FrogController>().isCrawling = false;
        other.gameObject.GetComponent<FrogController>().isFlying = true;
    }
}
