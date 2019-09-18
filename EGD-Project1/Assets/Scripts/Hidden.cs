using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hidden : MonoBehaviour
{
    public GameObject Char1;
    public GameObject Char2;
    public GameObject Char3;

    private bool wasActive;

    
    // Start is called before the first frame update
    void Start()
    {
        wasActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Char1.activeSelf && !Char3.activeSelf && !wasActive)
        {
            Char2.SetActive(true);
            wasActive = true;
        }
    }

}
