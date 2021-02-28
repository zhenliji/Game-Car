using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ARLoadScene : MonoBehaviour
{
    private float timer = 0f;
    //public TextMesh textMesh;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            timer += Time.deltaTime;
            if (timer > 1f)
            {
                SceneManager.LoadScene("Start");
            }
            //textMesh.text = timer.ToString("0.00");
        }
        Debug.DrawRay(transform.position, transform.forward);
    }
}
