using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEngine.Jobs;
using JetBrains.Annotations;

public class PlayerManager : MonoBehaviour
{
    public bool useStatic = false;
    public bool useBoxes = false;

    public bool normalMode = true;
    public float moveSpeed = 5f;
    public float jumpingPower = 10f;

    Vector2 movement;

    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    public Rigidbody2D rb;
    //public Animator animator;

    [SerializeField] public GameObject[] box;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Inputs
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Jump
        if (isGrounded() && !normalMode)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else if (!isGrounded() && !normalMode)
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        Debug.Log("Koskettaako maata: " + isGrounded());

        if (Input.GetKeyDown(KeyCode.W) && coyoteTimeCounter > 0f && !normalMode)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetKeyDown(KeyCode.W) && rb.velocity.y > 0f && !normalMode)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

            coyoteTimeCounter = 0f;
        }

        if (useStatic && useBoxes){
            for (int i = 0; i < box.Length; i++)
            {
                box[i].transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            }
        }

        else if(!useStatic && useBoxes){
            for (int i = 0; i < box.Length; i++)
            {
                box[i].transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }

    private void FixedUpdate()
    {
        //Movement
        if (normalMode == true)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
        
        else if(normalMode == false){
            rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DIE"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GOAL"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (collision.gameObject.CompareTag("ChangeToNormal"))
        {
            Debug.Log("Vaihda modea");
            rb.gravityScale = 0;
            normalMode = true;
        }

        if (collision.gameObject.CompareTag("ChangeToUnNormal"))
        {
            Debug.Log("Vaihda modea");
            rb.gravityScale = 1;
            normalMode = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ChangeMode"))
        {
            rb.gravityScale = 1;
            normalMode = false;
        }  
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ChangeMode"))
        {
            Debug.Log("Vaihda modea");
            rb.gravityScale = 0;
            normalMode = true;
        }
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
