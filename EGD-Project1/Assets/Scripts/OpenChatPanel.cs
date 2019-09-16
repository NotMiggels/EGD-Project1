using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChatPanel : MonoBehaviour
{
    public GameObject chatPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenChat()
    {
        chatPanel.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
