using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class board : MonoBehaviour
{

    public GameObject stone;
    public bool isUse = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.name == "UnityChanController") && !isUse)
        {
            Debug.Log("碰到了 石頭要出來啦");
            Instantiate(stone, this.transform.transform.position + new Vector3(0, 10, 0), new Quaternion());
            isUse = true;
        }
    }
}
