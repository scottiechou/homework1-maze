using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chestController : MonoBehaviour
{
    
    public Item key;
    GameObject open;
    GameObject close;
    DateTime openTime = new DateTime();

    public bool isOpen = false;
    // Use this for initialization
    void Start()
    {
        open = this.transform.Find("chest_open").gameObject;
        close = this.transform.Find("chest_close").gameObject;
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
                    if (inventory.AddItem(key))
                    {
                        open.SetActive(true);
                        close.SetActive(false);
                        text.text = "你拿到了 \"";
                        openTime = DateTime.Now;
                        if (key.name == "ColdDiaryItem")
                            text.text += "寒總的日記\"";
                        if (key.name == "KeyItem")
                            text.text += "鑰匙\"";
                        if (key.name == "MapItem")
                            text.text += "地圖\"";
                        if (key.name == "MarkItem")
                            text.text += "地圖標記\"";
                        isOpen = true;
                    }
                }
            }
        }
        if (DateTime.Now - openTime > new TimeSpan(0, 0, 5) && openTime != new DateTime())
        {
            openTime = new DateTime();
            text.text = "";
        }
    }
}
