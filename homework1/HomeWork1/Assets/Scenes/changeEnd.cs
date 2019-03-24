using System;
using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeEnd : MonoBehaviour
{

    public List<GameObject> end = new List<GameObject>();

    DateTime openTime = new DateTime();
    bool start = true;
    public Inventory inv;
    // Use this for initialization
    void Start()
    {
        GameObject inventory = GameObject.FindGameObjectWithTag("Inventory");
        if (inventory == null)
            Instantiate(inv);
        System.Random r = new System.Random();
        int number = r.Next() % 3;
        Text text = GameObject.Find("GetItem").GetComponent<Text>();
        if(start)
        {
            text.text = "你需要拿到 \"寒總的日記\"才能離開這裡";
            openTime = DateTime.Now;
            start = !start;
        }

        for (int i = 0; i < end.Count; i++)
        {
            if (number != i)
                end[i].SetActive(false);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        Text text = GameObject.Find("GetItem").GetComponent<Text>();
        if (DateTime.Now - openTime > new TimeSpan(0, 0, 3) && openTime != new DateTime())
        {
            openTime = new DateTime();
            text.text = "";
        }
    }
}
