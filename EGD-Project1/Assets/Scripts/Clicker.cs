using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clicker : MonoBehaviour
{
    public GameObject canv;
    public AudioSource clickSound;
    private GameObject temperateGo;
    private bool changeColor = false;
    private GameObject []GOA;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 raypos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
             Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        
        if (hit.collider != null)
        {
            temperateGo = hit.transform.gameObject;
            temperateGo.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 1f);
            changeColor = true;
        }

        if (changeColor == true && hit.collider == null)
        {
            temperateGo.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            changeColor = false;
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            //some presettings
            clickSound.Play();
            

            // "hit" checks current clicks
            if (hit.collider != null)
            {
                
                //printname can print the name of the object that mouse clicks on
                //PrintName(hit.transform.gameObject);
                
                // check name
                if (hit.transform.gameObject.name == "desktop")
                {
                    // and do whatever you wnana do
                    hit.transform.gameObject.GetComponent<OpenTwitter>().OpenCanvas();
                }

                if (hit.transform.gameObject.tag == "character")
                {
                    GameObject character = hit.transform.gameObject;
                    character.tag = "talkingto";
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
