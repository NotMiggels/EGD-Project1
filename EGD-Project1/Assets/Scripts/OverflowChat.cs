using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OverflowChat : MonoBehaviour
{
    public bool rightOrient;
    // Start is called before the first frame update
    void Start()
    {
        
        int textLength = CalculateLengthOfMessage();
        int leftPadding = (int)(0.00017 * textLength * textLength - 0.1662 * textLength - 8);
        int rightPadding = (int)(-0.0469 * textLength - 11);

        this.GetComponent<RectTransform>().sizeDelta = new Vector2(textLength, 100);
        //this.GetComponent<HorizontalLayoutGroup>().padding.left = leftPadding;
        //this.GetComponent<HorizontalLayoutGroup>().padding.right = rightPadding;
        if (rightOrient)
        {
            this.GetComponent<RectTransform>().anchoredPosition = new Vector3(200 - textLength / 2 + rightPadding, 1, 0);
            this.GetComponent<HorizontalLayoutGroup>().padding.right = leftPadding;
            this.GetComponent<HorizontalLayoutGroup>().padding.left = rightPadding;
        }
        else
        {
            this.GetComponent<RectTransform>().anchoredPosition = new Vector3(-213 + textLength / 2 - leftPadding, 1, 0);
            this.GetComponent<HorizontalLayoutGroup>().padding.left = leftPadding;
            this.GetComponent<HorizontalLayoutGroup>().padding.right = rightPadding;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
