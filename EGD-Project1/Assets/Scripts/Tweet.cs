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

    private GameObject firstlineGo;
    private GameObject secondlineGo;
    private GameObject thirdlineGo;
    // Start is called before the first frame update
    void Start()
    {
        alreadyLiked = false;
        // assign gos
        foreach (Transform t in this.transform)
        {
            if (t.name == "firstline")
            {
                firstlineGo = t.gameObject;
                foreach (Transform tt in t.transform)
                {
                    if (tt.name == "avatar")
                    {
                        avatarGo = tt.gameObject;
                    }
                    else if (tt.name == "name_date")
                    {
                        name_dateGo = tt.gameObject;
                    }
                }
            }
            else if (t.name == "secondline")
            {
                secondlineGo = t.gameObject;
                foreach (Transform tt in t.transform)
                {
                    if (tt.name == "content")
                    {
                        contentGo = tt.gameObject;
                    }
                    else if (tt.name == "image")
                    {
                        if (withImage)
                        {
                            tt.gameObject.SetActive(true);
                            imageGo = tt.gameObject;
                        }
                        else
                        {
                            tt.gameObject.SetActive(false);
                        }
                    }
                }
            }
            else if (t.name == "thirdline")
            {
                thirdlineGo = t.gameObject;
                foreach (Transform tt in t.transform)
                {
                    if (tt.name == "retweet")
                    {
                        retweetGo = tt.gameObject;
                    }
                    else if (tt.name == "comments")
                    {
                        commentGo = tt.gameObject;
                    }
                    else if (tt.name == "like")
                    {

                        likeGo = tt.gameObject;

                    }
                    else if (tt.name == "separateline")
                    {
                        separateGo = tt.gameObject;
                    }
                }
                    
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
        //content box height adjust
        contentGo.GetComponent<RectTransform>().sizeDelta = new Vector2(100, contentHeight + 17);
        //secondline height adjust
        if (withImage)
        {
            secondlineGo.GetComponent<RectTransform>().sizeDelta = new Vector2(100, contentHeight + 17 + 48.3f - contentGo.GetComponent<VerticalLayoutGroup>().padding.top);
            this.GetComponent<RectTransform>().sizeDelta = new Vector2(388.2f, contentHeight + 17 + 48.3f + 82 + 27 +
                this.GetComponent<VerticalLayoutGroup>().padding.top + this.GetComponent<VerticalLayoutGroup>().padding.bottom);
        } else
        {
            secondlineGo.GetComponent<RectTransform>().sizeDelta = new Vector2(100, contentHeight + 17 + 22 - contentGo.GetComponent<VerticalLayoutGroup>().padding.top);
            this.GetComponent<RectTransform>().sizeDelta = new Vector2(388.2f, contentHeight + 17 + 22 + 82 + 27 +  
                this.GetComponent<VerticalLayoutGroup>().padding.top + this.GetComponent<VerticalLayoutGroup>().padding.bottom);
        }
        
        //image pos adjust
        if (withImage)
        {
            imageGo.GetComponent<RectTransform>().anchoredPosition = new Vector3(19.9f,
                contentGo.GetComponent<RectTransform>().anchoredPosition.y + contentGo.GetComponent<RectTransform>().sizeDelta.y / 2 + contentGo.GetComponent<VerticalLayoutGroup>().padding.top - contentHeight + 37,
                0);
        }
    }
}
