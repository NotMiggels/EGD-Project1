using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LikeTweet : MonoBehaviour
{
    public Sprite redHeart;
    private bool liked = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Like()
    {
        if (liked == false)
        {
            this.GetComponent<Image>().sprite = redHeart;
            //this.GetComponentInChildren<Text>().text
        }
    }
}
