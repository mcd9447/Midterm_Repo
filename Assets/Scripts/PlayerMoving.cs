using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    public float speed = 3.0f;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    bool haveWater = false;

    public GameObject catText;
    public GameObject endText;

    void Start()
    {
        catText.SetActive(false);
        endText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 newPos = transform.position;

        /*if (Input.GetKey(KeyCode.W))
        {
            newPos.y += speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            newPos.x -= speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            newPos.y -= speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            newPos.x += speed * Time.deltaTime;
        }

        transform.position = newPos;*/

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "Cat")
        {
            catText.SetActive(true);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        //Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "Cat")
        {
            catText.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.gameObject.name);
        if(other.gameObject.name == "Water")
        {
            haveWater = true;
            Destroy(other.gameObject);
        }
        
        if (haveWater && other.gameObject.name == "Blanket")
        {
            endText.SetActive(true);
        }
    }

}