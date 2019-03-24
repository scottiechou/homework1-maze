using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titleUI : MonoBehaviour
{
    public GameObject nextcanvas;
    public Inventory Inventory;
    // Use this for initialization
    void Start()
    {
        //while(FindObjectOfType<Inventory>())
        // {
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Inventory"))
        {
            DestroyObject(item);
        }
        
        //}
        Instantiate(Inventory);
        nextcanvas.SetActive(false);
    }
    public void show()
    {
        nextcanvas.SetActive(true);
    }
    public void kill()
    {
        nextcanvas.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void endGame()
    {
        Application.Quit();
        Debug.Log("ended");
    }
}
