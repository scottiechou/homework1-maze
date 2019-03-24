using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class insideUI : MonoBehaviour {
    public GameObject exitcanvas,volumecanvas;
	// Use this for initialization
	void Start () {
        exitcanvas.SetActive(false);
        volumecanvas.SetActive(false);
	}
	public void show()
    {
        exitcanvas.SetActive(true);
    }
   
    public void showVolume()
    {
        volumecanvas.SetActive(true);
    }
    public void kill()
    {
        exitcanvas.SetActive(false);
    }
    
    public void killVolume()
    {
        volumecanvas.SetActive(false);
    }
	// Update is called once per frame
	void Update () {
        if (volumecanvas.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                killVolume();
        }
        if (exitcanvas.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                kill();
        }
	}

    public void endGame()
    {
        Application.Quit();
        Debug.Log("ended");
    }
}
