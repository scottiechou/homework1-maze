using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lockController : MonoBehaviour
{
    
    public GameObject wall;
    public Item Key;
    float wallheight = 2.6f;
    public bool isOpen = false;

    DateTime openTime = new DateTime();

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject UnityChan = GameObject.Find("UnityChanController");
        Text text = GameObject.Find("GetItem").GetComponent<Text>();
        if (!isOpen)
        {
            if (Vector3.Distance(UnityChan.transform.position, transform.position) < 1)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Inventory inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
                    
                    if (inventory.RemoveItem(Key))
                    {
                        isOpen = true;
                        text.text = "門已經打開了,如果沒看到可能需要尋找一下";
                        
                    }
                    else
                        text.text = "你必須要有鑰匙";
                    openTime = DateTime.Now;
                }
            }
        }
        else
        {
            if (wall.transform.position.y > (-wallheight) - 0.1f)
                wall.transform.position += new Vector3(0, -1 * Time.deltaTime, 0);
        }
        if (DateTime.Now - openTime > new TimeSpan(0, 0, 3) && openTime != new DateTime())
        {
            openTime = new DateTime();
            text.text = "";
        }
    }
}
