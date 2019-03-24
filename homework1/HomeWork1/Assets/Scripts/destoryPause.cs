using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destoryPause : MonoBehaviour {
    public GameObject canvas;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Destroy(canvas);
    }
    public void kill () {
        Destroy(canvas);
	}
}
