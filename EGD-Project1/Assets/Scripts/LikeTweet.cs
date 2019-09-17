using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LikeTweet : MonoBehaviour
{
    public Sprite redHeart;
    public Tweet tweetScript;
    private bool liked;
    // Start is called before the first frame update
    void Start()
    {
        liked = tweetScript.liked;
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
            tweetScript.liked = true;
            tweetScript.SetAllValues();
        }
    }
}
