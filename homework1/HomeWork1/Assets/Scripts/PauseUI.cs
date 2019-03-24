using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour {
    public GameObject Pause,subCanvas;
	// Use this for initialization
	void Start () {
        Pause.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!Pause.activeSelf)
                clickEvent();
            else if (!subCanvas.activeSelf)
                kill();
        }
	}
    public void clickEvent()
    {
        Cursor.visible = true;
        Pause.SetActive(true);
    }
    public void kill()
    {
        Cursor.visible = false;
        Pause.SetActive(false);
    }
}
