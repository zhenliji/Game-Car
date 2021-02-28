using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeclectCarModel : MonoBehaviour
{
    private GameObject[] carArray;
    private int index = 0;
    private Transform cartrans;
    private Quaternion cartransRotation;
    private GameObject nowObj;
    private void OnEnable()
    {
        if (cartrans)
        {
            cartrans.rotation = cartransRotation;
        }
    }
    void Start()
    {
        carArray = Resources.LoadAll<GameObject>("Prefabs");
        cartrans = transform.Find("CarTransform");
        cartransRotation = cartrans.rotation;

        nowObj = Instantiate(carArray[index], transform);
        nowObj.transform.position = cartrans.position;
        nowObj.transform.rotation = cartrans.rotation;
        GameController.Instance.CarIndex = index;
        index++;
    }

    void Update()
    {
        if (nowObj)
        {
            cartrans.transform.Rotate(Vector3.up * 0.5f, Space.World);
            nowObj.transform.rotation = cartrans.rotation;
        }
    }

    public void RightSelect()
    {
        if (index >= carArray.Length)
        {
            index = 0;
        }
        else if (index < 0)
        {
            index = 1;
        }
        Destroy(nowObj);
        nowObj = null;
        nowObj = Instantiate(carArray[index], transform);
        nowObj.transform.position = cartrans.position;
        nowObj.transform.rotation = cartrans.rotation;
        nowObj.transform.localScale = cartrans.localScale;
        GameController.Instance.CarIndex = index;
        index++;
    }

    public void LeftSelect()
    {
        if (index < 0)
        {
            index = carArray.Length - 1;
        }
        else if (index >= carArray.Length)
        {
            index = carArray.Length - 2;
        }
        Destroy(nowObj);
        nowObj = null;
        nowObj = Instantiate(carArray[index], transform);
        nowObj.transform.position = cartrans.position;
        nowObj.transform.rotation = cartrans.rotation;
        nowObj.transform.localScale = cartrans.localScale;
        GameController.Instance.CarIndex = index;
        index--;
    }
}
