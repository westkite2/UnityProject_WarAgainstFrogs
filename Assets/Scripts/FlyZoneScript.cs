using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyZoneScript : MonoBehaviour
{
    public GameManager GameManager;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("frog entered fly zone");
        GameManager.PlaySound("FROG");
        other.gameObject.GetComponent<FrogController>().isCrawling = false;
        other.gameObject.GetComponent<FrogController>().isFlying = true;
    }
}
