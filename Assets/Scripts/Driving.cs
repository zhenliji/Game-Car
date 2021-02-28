using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driving : MonoBehaviour
{
    // 四个车轮碰撞器
    private WheelCollider collider_FL;
    private WheelCollider collider_FR;
    private WheelCollider collider_BL;
    private WheelCollider collider_BR;
    // 四个车轮的模型
    private Transform model_FL;
    private Transform model_FR;
    private Transform model_BL;
    private Transform model_BR;
    // 车的引擎声音
    private AudioSource carEngineAudio;
    // 车轮转动的力（前面两个轮子）
    private float motorTorque = 1000;
    // 车轮在竖直方向转动的最大角度（前面两个轮子）
    private float steerAngle = 30;
    // 汽车的最大速度
    private float maxSpeed = 15;
    // 汽车的最小速度
    private float minSpeed = 3;
    // 汽车当前的速度
    private float currentSpeed;
    // 汽车的重心
    private Transform centerOfMass;

    void Start()
    {
        // 初始变量
        model_FL = transform.Find("WheelModel/FL");
        model_FR = transform.Find("WheelModel/FR");
        model_BL = transform.Find("WheelModel/BL");
        model_BR = transform.Find("WheelModel/BR");
        collider_FL = transform.Find("WheelCollider/FL").GetComponent<WheelCollider>();
        collider_FR = transform.Find("WheelCollider/FR").GetComponent<WheelCollider>();
        collider_BL = transform.Find("WheelCollider/BL").GetComponent<WheelCollider>();
        collider_BR = transform.Find("WheelCollider/BR").GetComponent<WheelCollider>();
        carEngineAudio = GetComponent<AudioSource>();
        centerOfMass = transform.Find("CenterOfMass");
        // 设置汽车重心
        GetComponent<Rigidbody>().centerOfMass = centerOfMass.localPosition;
        // 生成赛车
        GameController.Instance.CreateCarPlayer();
    }

    void Update()
    {
        // 汽车当前的速度
        currentSpeed = collider_FL.rpm * (collider_FL.radius * 2 * Mathf.PI) * 60 / 1000;
        // 汽车最大速度的判断条件（如果满足条件，继续施加驱动力为0，不满足条件继续施加不为0的驱动力）
        if ((currentSpeed >= maxSpeed && GameController.Instance.VertacalMove > 0) || (currentSpeed < -minSpeed && GameController.Instance.VertacalMove < 0))
        {
            collider_FL.motorTorque = 0;
            collider_FR.motorTorque = 0;
        }
        else
        {
            collider_FL.motorTorque = GameController.Instance.VertacalMove * motorTorque;
            collider_FR.motorTorque = GameController.Instance.VertacalMove * motorTorque;
        }
        // 控制车轮在竖直方向的转动（前面两个轮子）
        collider_FL.steerAngle = GameController.Instance.HorizontalMove * steerAngle;
        collider_FR.steerAngle = GameController.Instance.HorizontalMove * steerAngle;

        // 引擎声音（pitch声音播放的速度，volume声音的大小）
        carEngineAudio.pitch = 1 + Mathf.Abs((float)Math.Round((currentSpeed / maxSpeed), 1));
        carEngineAudio.volume = 0.1f + Mathf.Abs((float)Math.Round((currentSpeed / maxSpeed), 1));

        RotateWheel();
        SteerWheel();
    }

    // 车轮转动的方法
    void RotateWheel()
    {
        model_FL.GetChild(0).Rotate(collider_FL.rpm * 6 * Time.deltaTime * Vector3.right);
        model_FR.GetChild(0).Rotate(collider_FR.rpm * 6 * Time.deltaTime * Vector3.right);
        model_BL.Rotate(collider_BL.rpm * 6 * Time.deltaTime * Vector3.right);
        model_BR.Rotate(collider_BR.rpm * 6 * Time.deltaTime * Vector3.right);
    }
    // 车轮转向的方法
    void SteerWheel()
    {
        model_FL.localEulerAngles = new Vector3(model_FL.localEulerAngles.x, collider_FL.steerAngle, model_FL.localEulerAngles.z);
        model_FR.localEulerAngles = new Vector3(model_FL.localEulerAngles.x, collider_FL.steerAngle, model_FL.localEulerAngles.z);
    }
}
