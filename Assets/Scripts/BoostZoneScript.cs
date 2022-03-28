using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostZoneScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("frog entered boost zone");
        other.gameObject.GetComponent<FrogController>().isFlying = false;
        other.gameObject.GetComponent<FrogController>().isBoosting = true;
    }
}
