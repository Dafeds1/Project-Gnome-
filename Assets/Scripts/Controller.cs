using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Controller : MonoBehaviour
    {
        public float Speed;
        public float jumpForce;
        public float moveInput;
        public bool isGround = true;

        private Rigidbody2D rbPlayer;
        private Animation anim;


        void Start()
        {
            rbPlayer = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animation>();
        }

        
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && isGround)
            {
            rbPlayer.velocity = Vector2.up * jumpForce;
            
                isGround = false;
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
        moveInput = Input.GetAxis("Horizontal");
        rbPlayer.velocity = new Vector2(moveInput * Speed, rbPlayer.velocity.y);
        

    }

       
    }
