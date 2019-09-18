using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    public GameObject canv;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //some presettings
            Vector2 raypos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
             Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            // "hit" checks current clicks
            if (hit.collider != null)
            {
                //printname can print the name of the object that mouse clicks on
                PrintName(hit.transform.gameObject);
                
                // check name
                if (hit.transform.gameObject.name == "desktop")
                {
                    // and do whatever you wnana do
                    hit.transform.gameObject.GetComponent<OpenTwitter>().OpenCanvas();
                }

                if (hit.transform.gameObject.tag == "character")
                {
                    GameObject character = hit.transform.gameObject;
                    character.SetActive(false);
                    canv.SetActive(true);
                    canv.GetComponent<Dialogue>().dialogueStart(int.Parse(character.name));
                }

                // basically just write if functions and call public voids.
            }
            else
            {
                // if not click on any colliders
                print("no collider");
            }
        }
    }

    void PrintName (GameObject go)
    {
        print(go.name);
    }
}
