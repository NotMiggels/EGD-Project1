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
    public GameObject choicebox1;
    public GameObject choicebox2;
    private string path;
    public Text choice1;
    public Text choice2;

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
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            gameObject.SetActive(false);
        }
        dialoguePrint(dgrid, y);
        if (Input.GetMouseButtonDown(0) && dia){ 
            y++;
        }
        //check if dialogue has ended
        if (Input.GetMouseButtonDown(0) && !dia){ 
            y=1;
            gameObject.SetActive(false);
            dia = true;
            path = "";
        }
    }
    public void dialogueStart(int charnum){


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

    private void choice(){
        choicebox1.SetActive(true);
        choicebox2.SetActive(true);
        choice1.text = "Choice 1";
        choice2.text = "Choice 2";

    }
    private void dialoguePrint(string[,] grid, int y){
        dbox.text = grid[2,y];
        speaker.text = grid[1,y];
        //if the ID contains a c it has reached a choice
        if (grid[0,y].Contains('C'))
        {
            choice();
        }
        //if the ID contains an E it has reached the end
        if (grid[0,y].Contains('E'))
        {
            dia = false;
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
