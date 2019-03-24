using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeCamera : MonoBehaviour
{

    public GameObject cam;
    public bool isthird = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isthird)
                cam.transform.localPosition = new Vector3(0, 1.35f, 0.2f);
            else
                cam.transform.localPosition = new Vector3(0, 1.35f, -2f);
            isthird = !isthird;
        }
    }
}
