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


    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        theDM = FindObjectOfType<DialogManager>();

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

        
        float moveHorizontal = Input.GetAxis("Horizontal");
        // float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveSpeed * moveHorizontal, 0.0f);

        myRigidbody.velocity = movement;
    }

}