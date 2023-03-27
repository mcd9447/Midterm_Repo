using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tvscript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;

    public bool ifColliding = false;

    void ChangeSprite()
    {
        spriteRenderer.sprite = newSprite;
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (ifColliding && Input.GetKeyDown(KeyCode.Space))
        {
            //ChangeSprite(newSprite);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
        {
            ifColliding = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
        {
            ifColliding = false;
        }
    }
}
