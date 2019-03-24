using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class endController : MonoBehaviour
{
    public string nextScene;
    public float distance = 1.5f;
    public Item endItem = null;
    public Item Key,Map,Mark;
    DateTime openTime = new DateTime();
    DateTime firstTime;
    // Use this for initialization
    void Start()
    {
        firstTime = new DateTime();
    }

    // Update is called once per frame
    void Update()
    {
        Inventory inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        Text text = GameObject.Find("GetItem").GetComponent<Text>();
        GameObject UnityChan = GameObject.Find("UnityChanController");
        if (Vector3.Distance(this.transform.position, UnityChan.transform.position) < distance)
        {

            if (endItem == null || (endItem != null && inventory.FindItem(endItem) > -1))
            {

                if (firstTime == new DateTime())
                    firstTime = DateTime.Now;
                Debug.Log(firstTime);
                if (DateTime.Now - firstTime > new TimeSpan(0, 0, 3))
                {
                    while (inventory.RemoveItem(Map))
                    { }
                    while (inventory.RemoveItem(Mark))
                    { }
                    while (inventory.RemoveItem(Key))
                    { }
                    SceneManager.LoadScene(nextScene);
                    DontDestroyOnLoad(inventory);
                }
            }
            else
            {
                if (endItem.name == "ColdDiaryItem")
                    text.text = "你必須拿到 \"寒導的日記\"";
                if (endItem.name == "UnityChanDiaryItem")
                    text.text = "你必須拿到 \"Unity Chan的日記\"";
                if (endItem.name == "MapItem")
                    text.text = "你必須拿到 \"地圖\"";
                openTime = DateTime.Now;
            }

        }
        if (DateTime.Now - openTime > new TimeSpan(0, 0, 5) && openTime != new DateTime())
        {
            openTime = new DateTime();
            text.text = "";
        }
    }
}
