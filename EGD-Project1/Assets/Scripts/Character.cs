using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public int charNum;
    private SpriteRenderer charSprite;
    // Start is called before the first frame update
    void Start()
    {
        charSprite = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Disappear()
    {
        charSprite.color = new Color(1,1,1, 0);
    }

    public void Reappear()
    {
        charSprite.color = new Color(1,1,1,1);
    }
}
