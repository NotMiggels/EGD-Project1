using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendTweet : MonoBehaviour
{
    public Sprite jefeAvatar;
    public Text userInput;
    public GameObject tweetObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateTweet()
    {
        //print("printnow");
        GameObject go;
        go = Instantiate(tweetObject);

        Tweet goTweet = go.GetComponent<Tweet>();
        goTweet.tweet = userInput.text;
        goTweet.withImage = false;
        goTweet.username = "alittlejefe";
        goTweet.date = "Sep 20th";
        goTweet.retweet = 0;
        goTweet.comment = 0;
        goTweet.like = 0;
        goTweet.avatar = jefeAvatar;

        go.transform.parent = GameObject.Find("TweetContent").transform;
        go.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        go.transform.SetSiblingIndex(1);

        
    }
}
