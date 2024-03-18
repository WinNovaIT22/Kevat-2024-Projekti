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

    [SerializeField] public GameObject blockGoal;

    public bool canDash = false;
    private bool isDashing;
    public float dashingPower = 24f;
    public float dashingTime = 0.2f;
    public float dashingCooldown = 1f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PlayerPrefs.SetInt("GOAL", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing) 
        {
            return;
        }

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


        //Boxes can move
        if (useStatic){
            for (int i = 0; i < box.Length; i++)
            {
                box[i].transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            }
        }

        else{
            for (int i = 0; i < box.Length; i++)
            {
                box[i].transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
        }

        //Dash
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && normalMode)
        {
            StartCoroutine(Dash());
        }

        //Reset level
        if (Input.GetKeyDown(KeyCode.R) && PlayerPrefs.GetInt("isPaused") != 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

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
            PlayerPrefs.SetInt("GOAL", 1);
            PlayerPrefs.SetInt("UnlockedLevels", SceneManager.GetActiveScene().buildIndex + 1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (collision.gameObject.CompareTag("ChangeToNormal"))
        {
            Debug.Log("Vaihda modea");
            rb.gravityScale = 0;
            normalMode = true;
            useStatic = false;
            blockGoal.SetActive(true);
        }

        if (collision.gameObject.CompareTag("ChangeToUnNormal"))
        {
            Debug.Log("Vaihda modea");
            rb.gravityScale = 1;
            normalMode = false;
            useStatic = true;
            blockGoal.SetActive(false);
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

    //Dash
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;

        // Calculate the dash direction based on the movement vector
        Vector2 dashDirection = movement.normalized;

        // Set the velocity for dashing in the desired direction
        rb.velocity = dashDirection * dashingPower;

        // Wait for the specified dash time
        yield return new WaitForSeconds(dashingTime);

        // Reset velocity to zero after the dash is completed
        rb.velocity = Vector2.zero;

        // Reset the dashing flag
        isDashing = false;

        // Wait for the specified cooldown time
        yield return new WaitForSeconds(dashingCooldown);

        // Allow dashing again
        canDash = true;
    }

}
