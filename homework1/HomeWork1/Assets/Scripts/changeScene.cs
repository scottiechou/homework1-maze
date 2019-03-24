using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class changeScene : MonoBehaviour {
    public GameObject inventory;
    public void change(string name)
    {
        SceneManager.LoadScene(name);
        inventory = GameObject.FindGameObjectWithTag("Inventory");
        DontDestroyOnLoad(inventory);
    }

    public void changeToTitle()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("title");
    }
}
