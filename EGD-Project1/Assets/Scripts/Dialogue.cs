using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    private int day;
    public Text dbox;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            gameObject.SetActive(false);
        }
    }
    public void dialogueStart(int charnum){


        if (charnum == 1)
        {
            dbox.text = "Char 1";
        }
        if (charnum == 2)
        {
            dbox.text = "Char 2";
        }
        if (charnum == 3)
        {
            dbox.text = "Char 3";
        }
    }
}
