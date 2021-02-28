using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPlayer : MonoBehaviour
{
    private Transform carDring;
    private Transform[] transArray;
    private Transform[] transSelfArray;

    void Start()
    {
        carDring = GameObject.Find("CarDriving").transform;
        transArray = carDring.Find("WheelModel").GetComponentsInChildren<Transform>();
        transSelfArray = transform.GetComponentsInChildren<Transform>();
        transform.localScale = carDring.localScale;
    }

    void Update()
    {
        transform.position = carDring.position;
        transform.rotation = carDring.rotation;
        for (int i = 1; i < transArray.Length; i++)
        {
            transSelfArray[i].rotation = transArray[i].rotation;
        }
    }
}
