using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    private Rigidbody2D myRigidbody;

    public bool canMove;
    private DialogManager theDM;

    public Sprite armerHeinrich;
    public Sprite heinrichUndAgnes;
    private bool spriteChanged;
    private bool spriteChanged1;

    private Animator myAnimator;
    private bool playerMoving;
    private Vector2 lastMoveX;


    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        theDM = FindObjectOfType<DialogManager>();
        myAnimator = GetComponent<Animator>();

        canMove = true;
        spriteChanged = false;
        spriteChanged1 = false;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Sprite Changer" && spriteChanged == false)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = armerHeinrich;
            spriteChanged = true;
            moveSpeed = moveSpeed / 2;
        }

        if (other.tag == "Sprite Changer 1" && spriteChanged1 == false)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = heinrichUndAgnes;
            spriteChanged1 = true;
            moveSpeed = moveSpeed * 2;
        }
    }


    void Update() {
        playerMoving = false;

        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            playerMoving = true;
            lastMoveX = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }


        myAnimator.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        myAnimator.SetBool("PlayerMoving", playerMoving);
        myAnimator.SetFloat("LastMoveX", lastMoveX.x);
    }


    void FixedUpdate() {

        if(!theDM.dialogActive)
        {
            canMove = true;
        }

        if(!canMove)
        {
            myRigidbody.velocity = Vector2.zero;
            return;
        }

        
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        // float moveVertical = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(moveSpeed * moveHorizontal, 0.0f);

        myRigidbody.velocity = movement;
    }

}