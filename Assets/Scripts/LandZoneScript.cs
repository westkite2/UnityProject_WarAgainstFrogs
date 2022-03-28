using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandZoneScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("frog entered land zone");
        other.gameObject.GetComponent<FrogController>().isBoosting = false;
        other.gameObject.GetComponent<FrogController>().isLanding = true;
    }
}
