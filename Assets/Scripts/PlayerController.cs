using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    private float Speed = 15f;
    private float jumpForce = 300f;

    public bool isGround = true;

    private Rigidbody2D rbPlayer;
    private Animator animator;


    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            Vector3 jump = new Vector3(0f, jumpForce, 0f);
            rbPlayer.AddForce(jump);
            animator.SetTrigger("isJump");
            isGround = false;
            
        }
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("hitPick");
        }
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("hitFlame");
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") isGround = true;
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") isGround = false;
   
    }
    void FixedUpdate()
    {
        Movement();
    }

    public void Movement()
    {
        float MoveHorizontal = Input.GetAxis("Horizontal");
        if (MoveHorizontal > 0)
        {
            rbPlayer.velocity = Vector3.right * MoveHorizontal * Speed;
            animator.SetBool("isRun", true);
        }
        else if (MoveHorizontal < 0)
        {
            rbPlayer.velocity = Vector3.right * MoveHorizontal * Speed;
            animator.SetBool("isRun", true);
        }
        else animator.SetBool("isRun", false);
    }
}
