using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class AiCar : MonoBehaviour
{
    // 得到所有车轮
    private Transform[] wheelArray;
    // 是否开始游戏（当玩家开始移动时，AI车辆开始移动）
    private bool isStart;
    // AI车的初始位置
    private Vector3 oldCarPosition;
    // 玩家
    private Transform player;
    // 路径组件
    private DOTweenPath doTweenPath;
    private DOTweenPath doTweenPathTarget;
    // 看向的目标（用来控制车的朝向）
    public Transform lookAtTarget;

    void Start()
    {
        // 初始化变量
        player = GameObject.Find("CarDriving").transform;
        oldCarPosition = player.position;
        if (transform.childCount > 0)
        {
            wheelArray = new Transform[transform.childCount - 1];
            for (int i = 0; i < wheelArray.Length; i++)
            {
                wheelArray[i] = transform.GetChild(i);
            }
        }

        doTweenPath = GetComponent<DOTweenPath>();
        doTweenPathTarget = lookAtTarget.GetComponent<DOTweenPath>();
        // 暂停AI轨迹
        doTweenPath.DOPause();
        doTweenPathTarget.DOPause();
    }

    void Update()
    {
        if (lookAtTarget) transform.LookAt(lookAtTarget.position);

        if (Vector3.Distance(player.position, oldCarPosition) > 0.1f)
        {
            isStart = true;
            doTweenPath.DOPlay();
            doTweenPathTarget.DOPlay();
        }
        if (isStart)
        {
            if (transform.childCount > 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    transform.GetChild(i).Rotate(Vector3.right * 20);
                }
            }
        }
    }
}
