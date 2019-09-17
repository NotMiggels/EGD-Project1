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

    private GameObject contentGo;
    private GameObject avatarGo;
    private GameObject name_dateGo;
    private GameObject tweetGo;
    private GameObject imageGo;
    private GameObject retweetGo;
    private GameObject commentGo;
    private GameObject likeGo;
    private GameObject separateGo;
    // Start is called before the first frame update
    void Start()
    {
        alreadyLiked = false;
        foreach (Transform t in this.transform)
        {
            if (t.name == "avatar")
            {
                avatarGo = t.gameObject;
            }
            else if (t.name == "name_date")
            {
                name_dateGo = t.gameObject;
            }
            else if (t.name == "content")
            {
                contentGo = t.gameObject;
            }
            else if (t.name == "image")
            {
                if (withImage)
                {
                    t.gameObject.SetActive(true);
                    imageGo = t.gameObject;
                }
                else
                {
                    t.gameObject.SetActive(false);
                }
            }
            else if (t.name == "retweet")
            {
                retweetGo = t.gameObject;
            }
            else if (t.name == "comments")
            {
                commentGo = t.gameObject;
            }
            else if (t.name == "like")
            {

                likeGo = t.gameObject;

            }
        }
        SetAllValues();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAllValues()
    {
        avatarGo.GetComponent<Image>().sprite = avatar;
        name_dateGo.GetComponent<Text>().text = "<b>" + username + "</b>" + "  ·  " + date;
        contentGo.GetComponentInChildren<Text>().text = tweet;

        //image
        if (withImage)
        {
            imageGo.GetComponent<Image>().sprite = image;
        }

        retweetGo.GetComponentInChildren<Text>().text = retweet.ToString();
        commentGo.GetComponentInChildren<Text>().text = retweet.ToString();
        if (liked && !alreadyLiked)
        {
            like += 1;
            alreadyLiked = true;
        }
        likeGo.GetComponentInChildren<Text>().text = like.ToString();
        
        Text tweetText = contentGo.GetComponentInChildren<Text>();
        //print(20 /13);
        int contentHeight = (int)(tweetText.preferredHeight) - ((int)(tweetText.preferredHeight) / 25) * 11 ;
        if (withImage)
        {
            
            
            contentHeight += 50;
        }
        contentGo.GetComponent<RectTransform>().sizeDelta = new Vector2(100, contentHeight + 17);
        
        if (withImage)
        {
            imageGo.GetComponent<RectTransform>().anchoredPosition = new Vector3(19.9f,
                contentGo.GetComponent<RectTransform>().anchoredPosition.y + contentGo.GetComponent<RectTransform>().sizeDelta.y / 2 + contentGo.GetComponent<VerticalLayoutGroup>().padding.top - contentHeight + 37,
                0);
        }
    }
}
