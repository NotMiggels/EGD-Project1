using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("blahblah");
            Vector2 raypos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
             Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
           //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (hit.collider != null)
            {
                print("hit ever!");
                PrintName(hit.transform.gameObject);
            }
            else
            {
                print("no collider");
            }
        }
    }

    void PrintName (GameObject go)
    {
        print(go.name);
    }
}
