using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;

public class Options : MonoBehaviour
{
    public Text myChoice;
    public Chat chatControl;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D myBox = this.GetComponent<Collider2D>();
            //print("heyman");
            if (myBox.OverlapPoint(mousePos))
            {
                print("hey");
                Select();
            }
            //Select();
        }
        */

    }

    public void Select()
    {
        chatControl.SetMyChoice(myChoice.text);

    }
}
