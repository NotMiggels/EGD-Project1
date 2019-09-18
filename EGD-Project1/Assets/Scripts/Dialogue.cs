using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    private int day;
    private int y;
    private string[,] dgrid;
    private bool dia;
    public Text dbox;
    public GameObject mainbox;
    public GameObject choicebox1;
    public GameObject choicebox2;
    private string path;

    public Text speaker;
    public TextAsset csvDialogue;

    // Start is called before the first frame update
    void Start()
    {
        choicebox1.SetActive(false);
        choicebox2.SetActive(false);
        y = 1;
        dia = true;
        path = "";
        choicebox1.GetComponent<Button>().onClick.AddListener(pathchange1);
        choicebox2.GetComponent<Button>().onClick.AddListener(pathchange2);
        mainbox.GetComponent<Button>().onClick.AddListener(progess);
    }

    // Update is called once per frame
    void Update()
    {
        print(path);
        dialoguePrint(dgrid, y);
        if (dia && path != ""){ 
            for (int i = 0; i < dgrid.GetLength(1); i++)
            {
                if (dgrid[0,i].Contains(path+'E'))
                {
                    y=i;
                    break;

                }
                if (dgrid[0,i].Contains(path+'C'))
                {
                    y=i;
                    break;
                }
            }
        }
        //check if dialogue has ended
        if (Input.GetMouseButtonDown(0) && !dia){ 
            if(dgrid[0,y] == "N2E"||dgrid[0,y] == "N1E"){
                SceneManager.LoadScene(sceneName: "Theater");
            }
            if (SceneManager.GetActiveScene().name == "Theater")
            {
                SceneManager.LoadScene(sceneName: "BedroomDay2");
            }
            y=1;
            gameObject.SetActive(false);
            dia = true;
            path = "";
        }
    }
    public void dialogueStart(int charnum){
        if (SceneManager.GetActiveScene().name == "Lunchroom1")
        {
            if (charnum == 1)
            {  
                //speaker.text = "Bea";
                csvDialogue = Resources.Load<TextAsset>("Bea1");
                dgrid = csvGrid(csvDialogue.text);
            }
            if (charnum == 2)
            {
                speaker.text = "Natalie";
                csvDialogue = Resources.Load<TextAsset>("Natalie1");
                dgrid = csvGrid(csvDialogue.text);
            }
            if (charnum == 3)
            {
                //speaker.text = "Joe";
                csvDialogue = Resources.Load<TextAsset>("Joe1");
                dgrid = csvGrid(csvDialogue.text);
            }
        }
        if (SceneManager.GetActiveScene().name == "Theater")
        {
            if (charnum == 2)
            {
                speaker.text = "Natalie";
                csvDialogue = Resources.Load<TextAsset>("NatalieT");
                dgrid = csvGrid(csvDialogue.text);
            }
        }
        if (SceneManager.GetActiveScene().name == "Lunchroom2")
        {
            if (charnum == 1)
            {  
                //speaker.text = "Bea";
                csvDialogue = Resources.Load<TextAsset>("Bea1");
                dgrid = csvGrid(csvDialogue.text);
            }
            if (charnum == 2)
            {
                speaker.text = "Natalie";
                csvDialogue = Resources.Load<TextAsset>("Natalie1");
                dgrid = csvGrid(csvDialogue.text);
            }
            if (charnum == 3)
            {
                //speaker.text = "Joe";
                csvDialogue = Resources.Load<TextAsset>("Joe1");
                dgrid = csvGrid(csvDialogue.text);
            }
        }
    }

    private void choice(){
        choicebox1.SetActive(true);
        choicebox2.SetActive(true);
        choicebox1.GetComponentInChildren<Text>().text = dgrid[2,y+1];
        choicebox2.GetComponentInChildren<Text>().text = dgrid[2,y+2];
        mainbox.GetComponent<Button>().interactable = false;



    }
    void pathchange1(){
        choicebox1.SetActive(false);
        choicebox2.SetActive(false);
        path += '1';
    }
    void pathchange2(){
        choicebox1.SetActive(false);
        choicebox2.SetActive(false);
        path += '2';
    }
    void progess(){
        if (path == "")
        {
            y++;
        }
    }
    private void dialoguePrint(string[,] grid, int y){
        dbox.text = grid[2,y];
        speaker.text = grid[1,y];
        //if the ID contains a c it has reached a choice
        if (grid[0,y].Contains('C'))
        {
            print("choice");
            choice();
        }
        //if the ID contains an E it has reached the end
        if (grid[0,y].Contains('E'))
        {
            dia = false;
            choicebox1.SetActive(false);
            choicebox2.SetActive(false);
        }
    }
    static public string [,] csvGrid(string text){
        string []lines = text.Split("\n"[0]);

        int width = 0;
        for (int i = 0; i < lines.Length; i++)
        {
            string [] row = splitLine(lines[i]);
            width = Mathf.Max(width, row.Length);
        }

        string[,] output = new string[width + 1, lines.Length + 1];
        for (int y = 0; y < lines.Length; y++)
        {
            string[] row = splitLine( lines[y]);
            for (int x = 0; x < row.Length; x++)
            {
                output[x,y] = row[x];
            }
        }
        return output;
    }
    static public string[] splitLine(string line){
        return (from System.Text.RegularExpressions.Match m in System.Text.RegularExpressions.Regex.Matches(line,
		@"(((?<x>(?=[,\r\n]+))|""(?<x>([^""]|"""")+)""|(?<x>[^,\r\n]+)),?)", 
		System.Text.RegularExpressions.RegexOptions.ExplicitCapture)
		select m.Groups[1].Value).ToArray();
    }
}
