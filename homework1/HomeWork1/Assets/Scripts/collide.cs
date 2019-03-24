using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collide : MonoBehaviour {
    public GameObject unityChan;
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "UnityChanController")
        {
            collision.gameObject.transform.position = new Vector3(25,0.4f, 25);
       
            print("damn");
        }
    }
}
