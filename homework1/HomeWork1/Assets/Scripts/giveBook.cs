using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giveBook : MonoBehaviour {
    Inventory pack;
    public Item book;
    public List<GameObject> end = new List<GameObject>();
    public Inventory inv;
    // Use this for initialization
    void Start () {
        GameObject inventory = GameObject.FindGameObjectWithTag("Inventory");
        if (inventory == null)
            Instantiate(inv);
        pack = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        pack.AddItem(book);
        System.Random r = new System.Random();
        int number = r.Next() % 3;
        for (int i = 0; i < end.Count; i++)
        {
            if (number != i)
                end[i].SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
