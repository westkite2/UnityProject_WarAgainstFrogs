using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogManager : MonoBehaviour
{
    public GameObject Frog;
    public GameObject[] FrogList;
    private int total = 5;
    private int idx = 0;

    // Start is called before the first frame update
    void Start()
    {
        FrogList = new GameObject[total];
        for (int i = 0; i <total; i++)
        {
            GameObject frogObject = Instantiate(Frog);
            frogObject.transform.position =
                new Vector3(Random.Range(-0.8f, 0.8f),
                            Random.Range(0.05f, 0.05f),
                            Random.Range(-3.0f, -1.5f));
            FrogList[i] = frogObject;
            frogObject.SetActive(false);
            
        }
        StartCoroutine("EnableFrog");
    }
    IEnumerator EnableFrog()
    {
        yield return new WaitForSeconds(1f);
        FrogList[idx++].SetActive(true);
        if (idx == total) idx = 0;
        StartCoroutine("EnableFrog");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
