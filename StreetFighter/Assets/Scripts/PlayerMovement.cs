using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //Initialize Variables of Players
    public float MoveSpeed = 10f;
    public float JumpForce = 15f;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;


    private Rigidbody2D MyBody;
    private Animator Anim;
    private SpriteRenderer Sr;
    private string WALK_ANIMATION = "Walk";

    private bool IsGrounded;

    private void Awake()
    {
        MyBody = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        Sr = GetComponent<SpriteRenderer>();

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();
    }

    // Not Called Every Frame
    private void FixedUpdate()
    {
        PlayerJump();
    }

    //Moving the player horizontally (Follows a fixed interval that can be edited)
    void PlayerMoveKeyboard()
    {
        if (Input.GetKey(left))
        {
            transform.position += new Vector3(-MoveSpeed, 0f, 0f) * Time.deltaTime;
        }
        if (Input.GetKey(right))
        {
            transform.position += new Vector3(MoveSpeed, 0f, 0f) * Time.deltaTime;
        }
    }

    //Animate the Player
    void AnimatePlayer()
    {
        //If both left and right are pressed, no animations should be shown
        if (Input.GetKey(right) && Input.GetKey(left))
        {
            Anim.SetBool(WALK_ANIMATION, false);
        }

        //Player is moving RIGHT
        else if (Input.GetKey(right))
        {
            Anim.SetBool(WALK_ANIMATION, true);
            Sr.flipX = false;
        }
        //Player is moving LEFT
        else if (Input.GetKey(left))
        {
            Anim.SetBool(WALK_ANIMATION, true);
            Sr.flipX = true;
        }
        //Player is not moving
        else
        {
            Anim.SetBool(WALK_ANIMATION, false);
        }
    }

    //Player Jump Controller
    void PlayerJump()
    {
        if (Input.GetKeyDown(jump) && IsGrounded)
        {
            IsGrounded = false;
            MyBody.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
        }
    }

    //Checking to see if the player is on the ground so that he can jump again
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = true;
        }
    }
}

