using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMoving : MonoBehaviour
{
    //setting speed
    public float speed = 3.0f;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    bool haveWater = false;

    public GameObject catText;

    void Start()
    {
        //at start of game, meow isn't visible
        catText.SetActive(false);
    }

    void Update()
    {
        //player movement
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //player animation
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

    }

    private void FixedUpdate()
    {
        //moving independent of frames
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    //meow when colliding with cat
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Cat")
        {
            catText.SetActive(true);
        }
    }

    //stop meowing when no longer colliding with cat
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.name == "Cat")
        {
            catText.SetActive(false);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        //pick up water
        if (other.gameObject.name == "Water")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                haveWater = true;
                Destroy(other.gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
            //end game if you have water
            if (haveWater && other.gameObject.name == "Blanket")
        {
            SceneManager.LoadScene(0);
        }
    }

}