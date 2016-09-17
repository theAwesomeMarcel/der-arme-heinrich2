using UnityEngine;
using System.Collections;

public class dialogHolder : MonoBehaviour {

    public string dialogue;
    private DialogManager dMan;

    public string[] dialogueLines;

    

	// Use this for initialization
	void Start () {
        dMan = FindObjectOfType<DialogManager>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if(Input.GetKeyUp(KeyCode.Space))
            {
                //dMan.ShowBox(dialogue);

                if (!dMan.dialogActive)
                {   
                   
                    dMan.dialogLines = dialogueLines;
                    
                    dMan.currentLine = 0;
                    dMan.showDialog();
                }

                other.transform.gameObject.GetComponent<PlayerController>().canMove = false;
            }
        }

    }


}
