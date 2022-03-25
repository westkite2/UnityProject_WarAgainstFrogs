using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public GameObject HPbar;
    private Image HPfill;
    public float hp;

    // Start is called before the first frame update
    void Start()
    {
        HPfill = HPbar.transform.GetChild(1).GetComponent<Image>();
        hp = 100f;

    }

    // Update is called once per frame
    void Update()
    {
        HPfill.fillAmount = hp / 100f;
    }
}
