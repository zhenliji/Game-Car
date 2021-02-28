using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 平滑移动相机
public class SmoothFollow : MonoBehaviour
{
    // 相机高度
    private float height = 5;
    // 相机喝车子的距离
    private float distance = 10;
    // 相机看向的目标
    private Transform target;
    // 相机移动的速度
    private float smoothSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        // 初始化变量
        target = GameObject.Find("CarDriving").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetforward = target.forward;
        targetforward.y = 0;
        Vector3 currentforward = transform.forward;
        currentforward.y = 0;
        // 对位置信息进行插值
        Vector3 forward = Vector3.Lerp(currentforward.normalized, targetforward.normalized, smoothSpeed * Time.deltaTime);

        transform.position =target.position + Vector3.up * height - forward * distance;
        transform.LookAt(target);
    }
}
