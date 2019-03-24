using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class teachplay : MonoBehaviour
{

    public Text text;
    public int teachLevel = 1;
    public List<Button> lvl1 = new List<Button>();
    public GameObject lock_;
    public GameObject unitychan;
    public Inventory inv;
    List<bool> lvl1key = new List<bool>() { false, false, false, false, false };


    public GameObject canvasPrefab;
    bool enable = false;

    void Start()
    {
        GameObject inventory = GameObject.FindGameObjectWithTag("Inventory");
        if (inventory == null)
            Instantiate(inv);
        canvasPrefab.SetActive(false);
    }

    DateTime pressTime = new DateTime();
    // Update is called once per frame
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            enable = !enable;
            print(enable);
            if (enable)
                clickEvent();
            else
            {
                kill();
                Debug.Log("false");
            }
        }

        if (!enable)
        {
            if (teachLevel == 1)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    lvl1[0].image.color = Color.red;
                    lvl1key[0] = true;
                }
                if (Input.GetKey(KeyCode.A))
                {
                    lvl1[1].image.color = Color.red;
                    lvl1key[1] = true;
                }
                if (Input.GetKey(KeyCode.S))
                {
                    lvl1[2].image.color = Color.red;
                    lvl1key[2] = true;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    lvl1[3].image.color = Color.red;
                    lvl1key[3] = true;
                }
                if (Input.GetKey(KeyCode.Space))
                {
                    lvl1[4].image.color = Color.red;
                    lvl1key[4] = true;
                }

                //過關條件
                if (lvl1key.Count(t => !t) == 0)
                {
                    if (GoNextLevel(2))
                    {
                        for (int i = 0; i < lvl1.Count; i++)
                            DestroyObject(lvl1[i].gameObject);
                    }
                }
                else
                    text.text = "wasd 移動\n空白鍵+移動 可跳躍";
            }
            if (teachLevel == 2)
            {
                //過關條件
                board board = GameObject.Find("board").GetComponent<board>();
                if (!board.isUse)
                    text.text = "踩下陷阱會有掉落物從頭上掉落\n並且陷阱只能啟動一次";
                else
                    GoNextLevel(3);
            }
            if (teachLevel == 3)
            {
                lockController controller = lock_.GetComponent<lockController>();
                if(!controller.isOpen)
                    text.text = "開啟寶箱獲得鑰匙後,前往旁邊的檯子開啟通道";
                else
                    text.text = "踩上平台，三秒後進入下一關";
            }
        }
    }

    bool GoNextLevel(int level)
    {
        text.text = "長按 E 進入下一關";
        if (Input.GetKey(KeyCode.E))
        {
            if (!(pressTime == new DateTime()))
            {
                if (DateTime.Now - pressTime > new TimeSpan(0, 0, 3))
                {
                    unitychan.transform.position = new Vector3(15 + 10 * (level - 1), 0, 25);
                    teachLevel = level;
                    pressTime = new DateTime();
                    return true;
                }
            }
            else
                pressTime = DateTime.Now;
        }
        return false;
    }

    void clickEvent()
    {
        canvasPrefab.SetActive(true);
        //Instantiate(canvasPrefab, Vector3.zero, Quaternion.identity);
    }
    public void kill()
    {
        canvasPrefab.SetActive(false);
        //Destroy(GameObject.Find("Pause Canvas(Clone)"));
    }
}
