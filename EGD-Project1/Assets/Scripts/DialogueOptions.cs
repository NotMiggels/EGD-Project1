﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DialogueOptions : MonoBehaviour
{
    public Text myChoice;
    public Dialogue_F dialogueControl;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectA()
    {
        dialogueControl.SetMyChoice("A");
    }

    public void SelectB()
    {
        dialogueControl.SetMyChoice("B");
    }
    
}
