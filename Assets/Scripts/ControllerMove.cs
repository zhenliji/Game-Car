using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ControllerMove : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isNumber;
    private RawImage rawImage;
    public void OnPointerDown(PointerEventData eventData)
    {
        isNumber = true;
        rawImage.color = new Color(1f, 0.6f, 0.6f, 1f);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isNumber = false;
        rawImage.color = Color.white;
    }

    // Start is called before the first frame update
    void Start()
    {
        rawImage = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (isNumber)
        //{
        //    if (GameController.Instance.HorizontalMove >= 1)
        //    {
        //        GameController.Instance.HorizontalMove = 1;
        //    }
        //    else
        //    {
        //        GameController.Instance.HorizontalMove += Time.deltaTime;
        //    }
        //}
        //else
        //{
        //    if (GameController.Instance.HorizontalMove <= 0)
        //    {
        //        GameController.Instance.HorizontalMove = 0;
        //    }
        //    else
        //    {
        //        GameController.Instance.HorizontalMove -= Time.deltaTime;
        //    }

        //}
    }
}
