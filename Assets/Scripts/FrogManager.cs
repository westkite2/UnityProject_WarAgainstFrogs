using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogManager : MonoBehaviour
{
    public GameObject Frog;
    public GameManager GameManager;

    public Material yellow;
    public Material blue;
    public Material red;

    private GameObject[] Frog1List;
    private GameObject[] Frog2List;
    private GameObject[] Frog3List;
    private GameObject[] Frog4List;

    private int num1 = 10; //green
    private int num2 = 15; //yellow
    private int num3 = 15; //blue
    private int num4 = 25; //red

    private int idx1 = 0;
    private int idx2 = 0;
    private int idx3 = 0;
    private int idx4 = 0;

    // Start is called before the first frame update
    void Start()
    {        
        MakeFrog(ref Frog1List, num1, 0.05f, 1);
        MakeFrog(ref Frog2List, num2, 0.1f, 1, yellow);
        MakeFrog(ref Frog3List, num3, 0.08f, 2, blue, red);
        MakeFrog(ref Frog4List, num4, 0.2f, 1, red);
        StartCoroutine("EnableFrog");
    }
    IEnumerator EnableFrog()
    {
        if (GameManager.score <= 150)
        {
            yield return new WaitForSeconds(1f);            
            Frog1List[idx1++].SetActive(true);
            if (idx1 == num1) idx1 = 0;
        }
        else if (GameManager.score > 150 & GameManager.score <=300)
        {
            yield return new WaitForSeconds(1f);
            Frog1List[idx1++].SetActive(true);
            if (idx1 == num1) idx1 = 0;
            yield return new WaitForSeconds(1f);
            Frog2List[idx2++].SetActive(true);
            if (idx2 == num2) idx2 = 0;
        }
        else if (GameManager.score > 300 & GameManager.score <=600)
        {
            yield return new WaitForSeconds(1f);
            Frog2List[idx2++].SetActive(true);
            if (idx2 == num2) idx2 = 0;
            yield return new WaitForSeconds(1f);
            Frog2List[idx2++].SetActive(true);
            if (idx2 == num2) idx2 = 0;
            Frog1List[idx1++].SetActive(true);
            if (idx1 == num1) idx1 = 0;
        }
        else if (GameManager.score > 600 & GameManager.score <= 900)
        {
            yield return new WaitForSeconds(1f);
            Frog2List[idx2++].SetActive(true);
            if (idx2 == num2) idx2 = 0;
            Frog2List[idx2++].SetActive(true);
            if (idx2 == num2) idx2 = 0;
            yield return new WaitForSeconds(1f);
            Frog3List[idx3++].SetActive(true);
            if (idx3 == num3) idx3 = 0;
            yield return new WaitForSeconds(1f);
            Frog2List[idx2++].SetActive(true);
            if (idx2 == num2) idx2 = 0;
            Frog2List[idx2++].SetActive(true);
            if (idx2 == num2) idx2 = 0;
        }
        else if (GameManager.score > 900 & GameManager.score <= 1200)
        {
            yield return new WaitForSeconds(1f);
            Frog2List[idx2++].SetActive(true);
            if (idx2 == num2) idx2 = 0;
            Frog3List[idx3++].SetActive(true);
            if (idx3 == num3) idx3 = 0;
        }
        else if (GameManager.score > 1200 & GameManager.score <= 1500)
        {
            yield return new WaitForSeconds(1f);
            Frog3List[idx3++].SetActive(true);
            if (idx3 == num3) idx3 = 0;
            Frog3List[idx3++].SetActive(true);
            if (idx3 == num3) idx3 = 0;
            yield return new WaitForSeconds(1f);
            Frog4List[idx4++].SetActive(true);
            if (idx4 == num4) idx4 = 0;
            yield return new WaitForSeconds(1f);
            Frog3List[idx3++].SetActive(true);
            if (idx3 == num3) idx3 = 0;
            Frog3List[idx3++].SetActive(true);
            if (idx3 == num3) idx3 = 0;

        }
        else if (GameManager.score > 1500)
        {
            yield return new WaitForSeconds(0.5f);
            Frog4List[idx4++].SetActive(true);
            if (idx4 == num4) idx4 = 0;
            Frog4List[idx4++].SetActive(true);
            if (idx4 == num4) idx4 = 0;
        }

        StartCoroutine("EnableFrog");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GAMEOVER)
        {
            StopCoroutine("EnableFrog");
            for (int i = 0; i < num1; i++)
            {
                Frog1List[i].SetActive(false);
            }
            for (int i = 0; i < num2; i++)
            {
                Frog2List[i].SetActive(false);
            }
            for (int i = 0; i < num3; i++)
            {
                Frog3List[i].SetActive(false);
            }
            for (int i = 0; i < num4; i++)
            {
                Frog4List[i].SetActive(false);
            }

        }
    }
    private void MakeFrog(ref GameObject[] FrogList, int num, float speed, int power, Material color = null, Material tongue = null)
    {
        FrogList = new GameObject[num];
        for (int i = 0; i < num; i++)
        {
            GameObject frogObject = Instantiate(Frog);
            if (color) frogObject.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().material = color;
            if (tongue) frogObject.transform.GetChild(3).GetComponent<SkinnedMeshRenderer>().material = tongue;
            frogObject.transform.position =
                new Vector3(Random.Range(-0.8f, 0.8f),
                            Random.Range(0.05f, 0.05f),
                            Random.Range(-1.7f, -1.3f));
            frogObject.GetComponent<FrogController>().speed = speed;
            frogObject.GetComponent<FrogController>().power = power;
            FrogList[i] = frogObject;
            frogObject.SetActive(false);
        }
    }
}
