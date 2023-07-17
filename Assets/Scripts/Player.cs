using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float moveForce = 1f;

    [SerializeField]
    private float jumpForce = 11f;

    private float movementX;

    public Texture btnTexture;

    public Rigidbody2D myBody;

    private Animator anim;

    private SpriteRenderer sr;

    private bool isGrounded;

    private string WALK_ANIMATOR = "Walk";

    private string GROUND_TAG = "Ground";
    private string Enemy = "enemy";

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        sr = GetComponent<SpriteRenderer>();
    }

    //Initialization
    private void OnEnable()
    {
        

    }

    //reset is called when the script is attached and not in playmode.
    private void Reset()
    {
        
    }
    
    //start is only ever called once for a given script
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

    //FixedUpdate is called before each internal physics update
    private void FixedUpdate()
    {
        
    }
    void PlayerMoveKeyBoard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * moveForce * Time.deltaTime;        
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;            
        }

        if (collision.gameObject.CompareTag(Enemy))
        {
            gameObject.SetActive(false);  // avoidance
            Time.timeScale = 0.0f; // pause the game
        }


    }    

    public void Reset_Player() {

        Time.timeScale = 1.0f;
        gameObject.transform.SetPositionAndRotation(new Vector3(-1.77f, 1.47f, 0), Quaternion.identity);
        gameObject.SetActive(true);

    }

} // class
