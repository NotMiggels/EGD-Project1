using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OverflowChat : MonoBehaviour
{
    public bool rightOrient;
    //public GameObject Box; 
    // Start is called before the first frame update
    void Awake()
    {

        AdjustWidth();
        print("hjhj");
        //this.GetComponent<HorizontalLayoutGroup>().padding.left = leftPadding;
        //this.GetComponent<HorizontalLayoutGroup>().padding.right = rightPadding;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AdjustWidth()
    {
        int textLength = CalculateLengthOfMessage();
        int leftPadding = (int)(0.00017 * textLength * textLength - 0.1662 * textLength - 8);
        int rightPadding = (int)(-0.0469 * textLength - 11);

        this.GetComponent<RectTransform>().sizeDelta = new Vector2(textLength, 100);
        if (rightOrient)
        {
            this.GetComponent<RectTransform>().anchoredPosition = new Vector3(193 - textLength / 2 + rightPadding, 1, 0);
            this.GetComponent<HorizontalLayoutGroup>().padding.right = leftPadding;
            this.GetComponent<HorizontalLayoutGroup>().padding.left = rightPadding;
        }
        else
        {
            this.GetComponent<RectTransform>().anchoredPosition = new Vector3(-209 + textLength / 2 - leftPadding, 1, 0);
            this.GetComponent<HorizontalLayoutGroup>().padding.left = leftPadding;
            this.GetComponent<HorizontalLayoutGroup>().padding.right = rightPadding;
        }
    }

    private int CalculateLengthOfMessage()
    {
        int totalLength = 0;
        Text chatText = this.GetComponent<Text>();

        Font myFont = chatText.font;  //chatText is my Text component
        CharacterInfo characterInfo = new CharacterInfo();

        char[] arr = chatText.text.ToCharArray();

        foreach (char c in arr)
        {
            myFont.GetCharacterInfo(c, out characterInfo, chatText.fontSize);

            totalLength += characterInfo.advance;
        }

        return totalLength;
    }

    public void SetContent(string blah)
    {
        Text chatText = this.GetComponent<Text>();
        chatText.text = blah;
        AdjustWidth();
    }
}
