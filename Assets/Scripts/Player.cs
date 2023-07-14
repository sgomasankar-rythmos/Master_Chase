using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float moveForce = 10f;

    [SerializeField]
    private float jumpForce = 11f;

    private float movementX;

    public Rigidbody2D myBody;

    private Animator anim;

    private SpriteRenderer sr;

    private bool isGrounded;

    private string WALK_ANIMATOR = "Walk";

    private string GROUND_TAG = "Ground";

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        sr = GetComponent<SpriteRenderer>();
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyBoard();
        AnimatePlayer();
        PlayerJump();

    }    
    void PlayerMoveKeyBoard()
    {
        movementX = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(movementX, 0f, 0f) *moveForce * Time.deltaTime;

    }

    void AnimatePlayer()
    {
        if (movementX > 0)
        {
            anim.SetBool(WALK_ANIMATOR, true);
            sr.flipX = false;
        }

        else if (movementX < 0)
        {
            anim.SetBool(WALK_ANIMATOR, true);
            sr.flipX = true;
        }

        else
        {
            anim.SetBool(WALK_ANIMATOR, false);
        }

    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;            
        }
    }
} // class
