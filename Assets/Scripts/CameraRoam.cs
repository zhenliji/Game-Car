using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRoam : MonoBehaviour
{
    private Vector3 target;
    // 相机的初始位置
    private Vector3 oloPosition;
    void Start()
    {
        oloPosition = transform.position;
        StartCoroutine("SetTarget");
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target, 0.01f);
    }
    // 协程：让相机随机移动
    private IEnumerator SetTarget()
    {
        while (true)
        {
            target = new Vector3(oloPosition.x + Random.Range(-5f, 5f), oloPosition.y + Random.Range(-5f, 5f), oloPosition.z + Random.Range(-5f, 5f));
            yield return new WaitForSeconds(2);
        }
    }
}
