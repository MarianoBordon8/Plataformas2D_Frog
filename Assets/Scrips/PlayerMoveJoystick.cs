using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PlayerMoveJoistick : MonoBehaviour
{

    private float horizontalMove = 0f;
    private float verticalMove = 0f;
    public Joystick joystick;


    public float runSpeedHorizontal = 2;
    public float runSpeed = 1.25f;
    public float jumpSpeed = 2.65f;
    public float doubleJumpSpeed = 2;

    private bool canDoubleJump;
    public GameObject dustLeft;
    public GameObject dustRight;


    Rigidbody2D rb2D;

    public SpriteRenderer spriteRenderer;

    public Animator animator;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {

        if (horizontalMove > 0)
        {
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true);
            if (CheckGround.isGrounded == true)
            {
                dustLeft.SetActive(true);
                dustRight.SetActive(false);
            }

        }
        else if (horizontalMove < 0)
        {
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true);
            if (CheckGround.isGrounded == true)
            {
                dustRight.SetActive(true);
                dustLeft.SetActive(false);

            }
        }
        else
        {
            animator.SetBool("Run", false);
            dustRight.SetActive(false);
            dustLeft.SetActive(false);
        }

        if (CheckGround.isGrounded == false)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
            dustRight.SetActive(false);
            dustLeft.SetActive(false);
        }
        else if (CheckGround.isGrounded == true)
        {
            animator.SetBool("Jump", false);
            animator.SetBool("DoubleJump", false);
            animator.SetBool("Falling", false);
        }

        if (rb2D.velocity.y < 0)
        {
            animator.SetBool("Falling", true);
        }
        else if (rb2D.velocity.y > 0)
        {
            animator.SetBool("Falling", false);
        }
    }




    void FixedUpdate()
    {
        horizontalMove = joystick.Horizontal * runSpeedHorizontal;
        transform.position += new Vector3(horizontalMove, 0, 0) * Time.deltaTime * runSpeed;

    }
    public void Jump()
    {
        if (CheckGround.isGrounded)
        {
            canDoubleJump = true;
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
        }
        else
        {

            if (canDoubleJump)
            {
                animator.SetBool("DoubleJump", true);
                rb2D.velocity = new Vector2(rb2D.velocity.x, doubleJumpSpeed);
                canDoubleJump = false;
            }

        }
    }
}
