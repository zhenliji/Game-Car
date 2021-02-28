using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController instance;
    public static GameController Instance
    {
        get { return instance; }
    }
    private void Awake()
    {
        instance = this;
    }

    public SeclectCarModel seclectCarModel;
    private int carIndex;
    public int CarIndex
    {
        get { return carIndex; }
        set { carIndex = value; }
    }
    private float horizontalMove = 0;
    public float HorizontalMove
    {
        get { return horizontalMove; }
    }
    private float verticalMove = 0;
    public float VertacalMove
    {
        get { return verticalMove; }
    }
    private ControllerMove controllerMoveUp;
    private ControllerMove controllerMoveDown;
    private ControllerMove controllerMoveLeft;
    private ControllerMove controllerMoveRight;
    void Start()
    {
        if (GameObject.Find("SeclectCarModel"))
            seclectCarModel = GameObject.Find("SeclectCarModel").GetComponent<SeclectCarModel>();
        if (GameObject.Find("Canvas/ControllerMove/Up"))
        {
            controllerMoveUp = GameObject.Find("Canvas/ControllerMove/Up").GetComponent<ControllerMove>();
            controllerMoveDown = GameObject.Find("Canvas/ControllerMove/Down").GetComponent<ControllerMove>();
            controllerMoveLeft = GameObject.Find("Canvas/ControllerMove/Left").GetComponent<ControllerMove>();
            controllerMoveRight = GameObject.Find("Canvas/ControllerMove/Right").GetComponent<ControllerMove>();
        }
        // 切换场景不删除此脚本
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("SeclectCarModel") && !seclectCarModel)
            seclectCarModel = GameObject.Find("SeclectCarModel").GetComponent<SeclectCarModel>();
        if (!GameObject.Find("Canvas/ControllerMove/Up")) return;
        if (!controllerMoveRight)
        {
            controllerMoveUp = GameObject.Find("Canvas/ControllerMove/Up").GetComponent<ControllerMove>();
            controllerMoveDown = GameObject.Find("Canvas/ControllerMove/Down").GetComponent<ControllerMove>();
            controllerMoveLeft = GameObject.Find("Canvas/ControllerMove/Left").GetComponent<ControllerMove>();
            controllerMoveRight = GameObject.Find("Canvas/ControllerMove/Right").GetComponent<ControllerMove>();
        }
        if (controllerMoveRight.isNumber)
        {
            if (horizontalMove >= 1)
            {
                horizontalMove = 1;
            }
            else
            {
                horizontalMove += Time.deltaTime;
            }
        }
        else if (controllerMoveLeft.isNumber)
        {
            if (horizontalMove <= -1)
            {
                horizontalMove = -1;
            }
            else
            {
                horizontalMove -= Time.deltaTime;
            }
        }
        else
        {
            if (Mathf.Abs(horizontalMove) < 0.01f)
            {
                horizontalMove = 0;
            }
            else
            {
                horizontalMove = Mathf.Lerp(horizontalMove, 0, 0.1f);

            }
        }

        if (controllerMoveUp.isNumber)
        {
            if (verticalMove >= 1)
            {
                verticalMove = 1;
            }
            else
            {
                verticalMove += Time.deltaTime;
            }
        }
        else if (controllerMoveDown.isNumber)
        {
            if (verticalMove <= -1)
            {
                verticalMove = -1;
            }
            else
            {
                verticalMove -= Time.deltaTime;
            }
        }
        else
        {
            if (Mathf.Abs(verticalMove) < 0.01f)
            {
                verticalMove = 0;
            }
            else
            {
                verticalMove = Mathf.Lerp(verticalMove, 0, 0.1f);

            }
        }

    }
    public void CreateCarPlayer()
    {
        Instantiate(Resources.LoadAll<GameObject>("Prefabs")[CarIndex], null).AddComponent<CarPlayer>();
    }
}
