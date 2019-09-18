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
      

    }

    public void Select()
    {
        chatControl.SetMyChoice(myChoice.text);

    }
}
