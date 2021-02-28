using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    void Start()
    {
        transform.Find("ExplainPlane").localScale = new Vector3(0f, transform.Find("Exit").localScale.y, transform.Find("Exit").localScale.z);
        transform.Find("Start").GetComponent<Button>().onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Main");
        });
        transform.Find("Explain").GetComponent<Button>().onClick.AddListener(() =>
        {
            if (coroutine != null) StopCoroutine(coroutine);
            if (transform.Find("ExplainPlane").localScale.x == 1)
            {
                coroutine = StartCoroutine(ShowPlane(transform.Find("ExplainPlane"), new Vector3(0, 1, 1)));
            }
            else
            {
                coroutine = StartCoroutine(ShowPlane(transform.Find("ExplainPlane"), Vector3.one));
                transform.Find("SelectCar").gameObject.SetActive(false);
            }
        });
        transform.Find("Exit").GetComponent<Button>().onClick.AddListener(() =>
        {
            if (SceneManager.GetActiveScene().name == "Start")
            {
                Application.Quit();
            }
            else if (SceneManager.GetActiveScene().name == "Main")
            {
                SceneManager.LoadScene("Start");
            }
        });
        if (transform.Find("SelectCar"))
        {
            transform.Find("SelectCar").gameObject.SetActive(false);
            transform.Find("SelectCarButton").GetComponent<Button>().onClick.AddListener(() =>
            {
                if (coroutine != null) StopCoroutine(coroutine);
                if (transform.Find("SelectCar").gameObject.activeSelf)
                {
                    transform.Find("SelectCar").gameObject.SetActive(false);
                    GameController.Instance.seclectCarModel.enabled = false;
                }
                else
                {
                    transform.Find("SelectCar").gameObject.SetActive(true);
                    coroutine = StartCoroutine(ShowPlane(transform.Find("ExplainPlane"), new Vector3(0, 1, 1)));
                    GameController.Instance.seclectCarModel.enabled = true;
                }
            });
        }
    }

    void Update()
    {

    }
    private Coroutine coroutine;
    IEnumerator ShowPlane(Transform t, Vector3 v)
    {
        while (Vector3.Distance(t.localScale, v) > 0.1f)
        {
            t.localScale = Vector3.Lerp(t.localScale, v, 0.1f);
            yield return null;
        }
        t.localScale = v;
    }
}
