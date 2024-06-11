using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public GameObject StatsManagerObj;
    public StatsManager StatsManager;

    private float horizontal;
    public float speed = 8f;
    public float jumpingPower = 10f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;


    void Update()
    {

        StatsManagerObj = GameObject.FindWithTag("StatsManager");
        StatsManager = StatsManagerObj.GetComponent<StatsManager>();

        if (StatsManager.energy < 1) 
        {
            SceneManager.LoadScene("Limbo");
        }


        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("H2O"))
        {
            StatsManager.water++;
        }

        if (collision.gameObject.CompareTag("CO2"))
        {
            StatsManager.carbon++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("EvilDoor"))
        {
            StatsManager.energy = StatsManager.energy - 5;
        }

        if (collision.gameObject.CompareTag("Light"))
        {
            if (StatsManager.water > 9 && StatsManager.carbon > 9)
            {
                StatsManager.energy = StatsManager.energy + 5;
                StatsManager.water = StatsManager.water - 10;
                StatsManager.carbon = StatsManager.carbon - 10;

            }
        }
    }

}
