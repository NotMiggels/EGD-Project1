using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class DialogueText
{
    public int textNum;
    public string name;
    public string content;
    public bool needSelection;
    public List<string> choices;
    public List<int> linkTo;
    public bool lastDialogue;
    public bool ending1;
    public bool ending2;
}

public class Dialogue_F : MonoBehaviour
{
    public List<DialogueText> joe;
    public List<DialogueText> bea;
    public List<DialogueText> natalie;

    public int curIndex;
    private int joeIndex;
    private int beaIndex;

    public GameObject dialogueBox;
    public GameObject nameBox;
    public GameObject choiceA;
    public GameObject choiceB;
    public string myChoice;

    public string next;

    public bool joeDone = false;
    public bool beaDone = false;

    public GameObject joeGo;
    public GameObject beaGo;
    public GameObject natGo;

    public GameObject profileGo;
    public Sprite joeS;
    public Sprite beaS;
    public Sprite natS;

    public int nextScene;

    //private int charIndex;
    // Start is called before the first frame update
    void Start()
    {
        curIndex = 0;
        joeIndex = 0;
        beaIndex = 0;
        //charIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckDialogue(int index)
    {
        
        if (index == 1)
        {
            profileGo.GetComponent<Image>().sprite = beaS;
            StartCoroutine(StartDialogue(bea));
        } else if (index == 2)
        {
            profileGo.GetComponent<Image>().sprite = natS;
            StartCoroutine(StartDialogue(natalie));
        } else if (index == 3)
        {
            profileGo.GetComponent<Image>().sprite = joeS;
            StartCoroutine(StartDialogue(joe));
        } else
        {
            print("wrong index:" + index);

        }
    }

    public IEnumerator StartDialogue (List<DialogueText> charName)
    {
        bool needSelect = false;
        if (charName == joe)
        {
            curIndex = joeIndex;
        }
        if (charName == bea)
        {
            curIndex = beaIndex;
        }
        if (charName == natalie)
        {
            curIndex = 0;
        }
        while (true)
        {
            print(curIndex);
            needSelect = charName[curIndex].needSelection;
            nameBox.GetComponentInChildren<Text>().text = charName[curIndex].name;
            dialogueBox.GetComponentInChildren<Text>().text = charName[curIndex].content;

            //if needs select
            if (needSelect)
            {
                if (charName[curIndex].choices.Count != 2)
                {
                    print("hey where is your choices??");
                }
                else
                {
                    choiceA.GetComponentInChildren<Text>().text = charName[curIndex].choices[0];
                    choiceB.GetComponentInChildren<Text>().text = charName[curIndex].choices[1];
                    choiceA.SetActive(true);
                    choiceB.SetActive(true);
                    yield return StartCoroutine(WaitForActions());
                    
                    if (myChoice == "A")
                    {
                        curIndex = charName[curIndex].linkTo[0];
                    }
                    else
                    {
                        curIndex = charName[curIndex].linkTo[1];
                    }
                    choiceA.SetActive(false);
                    choiceB.SetActive(false);
                    //print("blah");
                    //print (myChoice);
                }

            } else
            {
                dialogueBox.GetComponent<Button>().enabled = true;
                yield return StartCoroutine(WaitForNext());
                dialogueBox.GetComponent<Button>().enabled = false;
                if (charName[curIndex].lastDialogue)
                {
                    print("dialogueover");
                    if (charName == natalie)
                    {
                        yield return new WaitForSeconds(1.5f);
                        if (charName[curIndex].ending1)
                        {
                            SceneManager.LoadScene(9);
                        }
                        else if (charName[curIndex].ending2)
                        {
                            SceneManager.LoadScene(10);
                        }
                        else
                        {
                            SceneManager.LoadScene(nextScene);
                        }
                        
                    }
                    else if (joeDone == false && charName == joe)
                    {
                        print("1");
                        joeDone = true;
                        joeIndex = curIndex;
                        if (beaDone)
                        {
                            natGo.SetActive(true);
                            
                        } else
                        {
                            joeGo.SetActive(true);
                            beaGo.SetActive(true);
                        }
                        
                        this.gameObject.SetActive(false);
                    }
                    else if (beaDone == false && charName == bea)
                    {
                        print("2");
                        beaDone = true;
                        beaIndex = curIndex;
                        if (joeDone)
                        {
                            natGo.SetActive(true);

                        } else
                        {
                            joeGo.SetActive(true);
                            beaGo.SetActive(true);
                        }
                        
                        this.gameObject.SetActive(false);
                    }
                    
                    else
                    {
                        print("5");
                        joeGo.SetActive(true);
                        beaGo.SetActive(true);
                        this.gameObject.SetActive(false);
                    }
                    break;
                }
                print("yea");
                curIndex = charName[curIndex].linkTo[0];

            }

            

            //index = texts[index].linkTo;
        }
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

    public IEnumerator WaitForNext()
    {
        next = null;
        while (next == null)
        {
            yield return null;
        }
    }

    public void SetMyChoice(string choice)
    {
        myChoice = choice;
    }

    public void SetNext(string n)
    {
        next = n;
    }
}
