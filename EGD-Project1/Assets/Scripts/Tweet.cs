using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tweet : MonoBehaviour
{
    
    public Sprite avatar;
    public string username;
    public string date;

    [TextArea]
    public string tweet;

    public bool withImage;
    public Sprite image;

    public int retweet;
    public int comment;

    public bool liked;
    private bool alreadyLiked;
    public int like;

    // Start is called before the first frame update
    void Start()
    {
        alreadyLiked = false;
        SetAllValues();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAllValues()
    {
        foreach (Transform t in this.transform)
        {
            if (t.name == "avatar")
            {
                t.GetComponent<Image>().sprite = avatar;
            } else if (t.name == "name_date")
            {
                t.GetComponent<Text>().text = "<b>" + username + "</b>" + "  ·  " + date;
            } else if (t.name == "content")
            {
                t.GetComponentInChildren<Text>().text = tweet;
            } else if (t.name == "image")
            {
                if (withImage)
                {
                    t.gameObject.SetActive(true);
                    t.GetComponent<Image>().sprite = image;
                } else
                {
                    t.gameObject.SetActive(false);
                }
            } else if (t.name == "retweet")
            {
                t.GetComponentInChildren<Text>().text = retweet.ToString();
            } else if (t.name == "comments")
            {
                t.GetComponentInChildren<Text>().text = comment.ToString();
            } else if (t.name == "like")
            {
                if (liked && !alreadyLiked)
                {
                    like += 1;
                    alreadyLiked = true;
                }
                t.GetComponentInChildren<Text>().text = like.ToString();
                
            }
        }
    }
}
