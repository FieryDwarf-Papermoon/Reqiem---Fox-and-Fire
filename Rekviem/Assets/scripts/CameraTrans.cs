using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrans : MonoBehaviour
{

    public float panSpeed = 0.05f;
    public float zoomSpeed = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //float dx = panSpeed * Input.GetAxis("Horizontal");
        //float dy = panSpeed * Input.GetAxis("Vertical");

        //Camera.main.transform.Translate(dx, dy, 0);

        //Debug.Log(" x = " + Input.GetAxis("Horizontal") + " y = " + Input.GetAxis("Vertical"));

        float dz = zoomSpeed * Input.GetAxis("Zoom");

        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize + dz, 2f, 20f);
    }
}
