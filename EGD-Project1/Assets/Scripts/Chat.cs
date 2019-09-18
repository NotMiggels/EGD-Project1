using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


[System.Serializable]
public class ChatText
{
    public int textNum;
    public string content;
    public bool needSelection;
    public List<string> choices;
    //public bool branching;
    public List<int> linkTo;
    public bool lastDialogue;
}

public class Chat : MonoBehaviour
{
    public List<ChatText> texts;

    public int index;
    public GameObject girlBox;
    public GameObject myBox;

    public GameObject choiceA;
    public GameObject choiceB;
    public string myChoice;

    public ScrollRect sRect;
    private GameObject vertBar;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        vertBar = GameObject.Find("Chat Vertical");
        StartCoroutine(ChatStart());
        //CreateChatBox(true, "nya");
        //CreateChatBox(false, "okie dokie andhjhjhjhjhjhj.");
        //ChatStart();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public IEnumerator ChatStart()
    {
        bool checkTurn = false;
        while(true)
        {
            
            checkTurn = texts[index].needSelection;
            print(checkTurn);
            if (checkTurn)
            {
                if (texts[index].choices.Count != 2)
                {
                    print("hey where is your choices??");
                }
                else
                {
                    choiceA.GetComponentInChildren<Text>().text = texts[index].choices[0];
                    choiceB.GetComponentInChildren<Text>().text = texts[index].choices[1];
                    choiceA.SetActive(true);
                    choiceB.SetActive(true);
                    yield return StartCoroutine(WaitForActions());
                    CreateChatBox(checkTurn, myChoice);
                    if (index >= 5)
                    {
                        sRect.velocity = new Vector2(0f, 1000f);
                    }

                    //yield return StartCoroutine(ScrollToBottom());
                    if (myChoice == texts[index].choices[0])
                    {
                        index = texts[index].linkTo[0];
                    }
                    else
                    {
                        index = texts[index].linkTo[1];
                    }
                    choiceA.SetActive(false);
                    choiceB.SetActive(false);
                    //print("blah");
                    //print (myChoice);
                }

            }
            else
            {
                
                yield return new WaitForSeconds(1);
                CreateChatBox(checkTurn, texts[index].content);
                if (index >= 5)
                {
                    sRect.velocity = new Vector2(0f, 1000f);
                }
                //Canvas.ForceUpdateCanvases();
                //yield return StartCoroutine(ScrollToBottom());
                if (texts[index].lastDialogue)
                {
                    print("scene change");
                    
                    break;
                    //Change scene
                }
                
                index = texts[index].linkTo[0];

            }
            
            //index = texts[index].linkTo;
        }
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(6);
        // do something like jump to another scene
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

    public IEnumerator WaitForActions()
    {
        myChoice = null;
        while (myChoice == null)
        {
            //print(myChoice);
            yield return null;
        }
    }
    
    public void SetMyChoice(string choice)
    {
        myChoice = choice;
    }
}
