using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class checkMap : MonoBehaviour
{
    public RawImage map;
    public Camera cam;
    public Item i_map,i_mark;
    Inventory inventory;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        if (inventory.FindItem(i_map) > -1)
            map.enabled = true;
        else
            map.enabled = false;
        if(inventory.FindItem(i_mark) > -1)
        {
            Camera c = cam.GetComponent<Camera>();
            c.cullingMask =LayerMask.GetMask("point","Default");
        }
    }
}
