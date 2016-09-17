using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    private Rigidbody2D myRigidbody;

    public bool canMove;
    private DialogManager theDM;


    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        theDM = FindObjectOfType<DialogManager>();

        canMove = true;
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