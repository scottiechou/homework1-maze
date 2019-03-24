using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class diaryController : MonoBehaviour
{

    public GameObject canvas;
    public Item cold, unity;
    public Text diaryText;

    public void showItem()
    {
        canvas.SetActive(true);
    }
    public void killItem()
    {
        canvas.SetActive(false);
    }

    // Use this for initialization
    void Start()
    {
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (canvas.activeSelf)
            {
                Cursor.visible = false;
                killItem();
            }
            else
            {
                Cursor.visible = true;
                showItem();
            }
        }
    }

    public void coldDiary()
    {
        
        Inventory inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        if (inventory.FindItem(cold) > -1)
            diaryText.text = "貨進得來。\n人出的去。\n大家發大財。";
        else
            diaryText.text = "你必須拿到此物品";
        
    }
    
    public void unityDiary()
    {
        Inventory inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        if (inventory.FindItem(unity) > -1)
            diaryText.text = "時逢2020，在這個名為福爾摩斯的島嶼有一個偉大的領導-人稱寒流的寒總，帶領一群勇敢的戰士，為了抵禦鄰國的侵略而勇敢作戰，但不幸的是，鄰國的首領-喜負評" +
                "使用名為毆富堡的超級兵器將我們一網打盡，而我自己一人被關在這個簡陋的迷宮中，一定要逃離這個地方，並找到寒總的日記，裡面記載了" +
                "如何打倒喜負評的方法。";
        else
            diaryText.text = "你必須拿到此物品";
    }
}
