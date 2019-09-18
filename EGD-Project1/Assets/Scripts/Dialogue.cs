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
    public Text dbox;
    public Text speaker;
    public TextAsset csvDialogue;

    // Start is called before the first frame update
    void Start()
    {
        y = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            gameObject.SetActive(false);
        }
        dialoguePrint(dgrid, y);
        if (Input.GetMouseButtonDown(0)){
            print("yes");
            y++;
        }
    }
    public void dialogueStart(int charnum){


        if (charnum == 1)
        {  
            speaker.text = "Bea";
        }
        if (charnum == 2)
        {
            speaker.text = "Natalie";
        }
        if (charnum == 3)
        {
            //speaker.text = "Joe";
            csvDialogue = Resources.Load<TextAsset>("Joe1");
            dgrid = csvGrid(csvDialogue.text);
            
            //dbox.text = dgrid[2,1];
        }
    }

    private void dialoguePrint(string[,] grid, int y){
        dbox.text = grid[2,y];
        speaker.text = grid[1,y];
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
