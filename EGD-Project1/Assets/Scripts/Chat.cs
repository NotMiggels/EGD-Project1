using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ChatText
{
    public string content;
    public bool needSelection;
    public List<string> choices;
}

public class Chat : MonoBehaviour
{
    public List<ChatText> texts;

    public int index;
    public GameObject girlBox;
    public GameObject myBox;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        CreateChatBox(true, "nya");
        CreateChatBox(false, "okie dokie andhjhjhjhjhjhj.");
        //ChatStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChatStart()
    {
        bool checkTurn = false;
        for (index = 0; index < texts.Count -1; index++)
        {
            checkTurn = texts[index].needSelection;
            if (checkTurn)
            {
                //next doing choices have to sleep
            }
        }
    }

    public void CreateChatBox(bool myTurn, string text)
    {
        GameObject go;
        
        if (myTurn)
        {
            go = Instantiate(myBox);
            
        }
        else
        {
            go = Instantiate(girlBox);
            
        }
        go.transform.parent = GameObject.Find("ChatContent").transform;
        go.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);

        OverflowChat overScript = go.GetComponentInChildren<OverflowChat>();
        overScript.SetContent(text);
        overScript.AdjustWidth();
        

    }
}
