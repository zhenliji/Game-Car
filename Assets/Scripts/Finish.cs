using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    float timer;
    bool isFinish;
    private GameObject victory;
    private GameObject defeated;
    private Dictionary<string, int> loopNum = new Dictionary<string, int>();
    void Start()
    {
        victory = GameObject.Find("Canvas/victory");
        defeated = GameObject.Find("Canvas/defeated");
        victory.SetActive(false);
        defeated.SetActive(false);

    }
    private void Update()
    {

        if (isFinish)
        {
            timer += Time.deltaTime;
        }
        if (timer > 5f)
        {
            SceneManager.LoadScene("Start");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        int n;
        print(loopNum.TryGetValue(other.name, out n));
        if (loopNum.TryGetValue(other.name, out n))
        {
            n++;
            if (n >= 3)
            {
                isFinish = true;
            }
            loopNum[other.name] = n;
        }
        else
        {
            loopNum.Add(other.name, 1);
        }
        if (isFinish)
        {
            if (other.name == "CarDriving")
            {
                victory.SetActive(true);
            }
            else
            {
                defeated.SetActive(true);
            }
        }
        foreach (KeyValuePair<string, int> item in loopNum)
        {
            print(item.Key + "..." + item.Value);
        }
    }
}
