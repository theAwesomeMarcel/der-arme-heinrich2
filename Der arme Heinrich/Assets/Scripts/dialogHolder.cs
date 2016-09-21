using UnityEngine;
using System.Collections;

public class dialogHolder : MonoBehaviour {

    public string dialogue;
    private DialogManager dMan;

    public string[] dialogueLines;

    private QuestItem theQI;
    private QuestManager theQM;

    public bool quest;
    public int itemCounter;

    public int idSzene;
    
	// Use this for initialization
	void Start () {
        dMan = FindObjectOfType<DialogManager>();
        theQM = FindObjectOfType<QuestManager>();
	}
	
	// Update is called once per frame
	void Update () {

        if (dMan.szenenStelle == 3)
        {
            theQM.quests[0].gameObject.SetActive(true);
            theQM.quests[1].gameObject.SetActive(true);
            theQM.quests[2].gameObject.SetActive(true);

            if (theQM.questCompleted[0] && theQM.questCompleted[1] && theQM.questCompleted[2])
            {
                dMan.erforderlicheQuest[3] = true;
            }          
        }


        if (dMan.szenenStelle == 7)
        {
            theQM.quests[3].gameObject.SetActive(true);
            theQM.quests[4].gameObject.SetActive(true);

            if (theQM.questCompleted[3] && theQM.questCompleted[4])
            {
                dMan.erforderlicheQuest[7] = true;
            }
        }

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player" && dMan.szenenStelle == idSzene && dMan.erforderlicheQuest[dMan.szenenStelle] == true) //&& dMan.permissionSzene[dMan.szenenStelle] == true
        {   
            if(Input.GetKeyUp(KeyCode.Space) )
            {
                //dMan.ShowBox(dialogue);

                if (!dMan.dialogActive)
                {   
                   
                    dMan.dialogLines = dialogueLines;
                    
                    dMan.currentLine = 0;
                    dMan.showDialog();

                    //szene deaktivieren, hochzähelen und nächste Szene aktivieren
                    dMan.permissionSzene[dMan.szenenStelle] = false;
                    dMan.szenenStelle++;
                    dMan.permissionSzene[dMan.szenenStelle] = true;
                }

                other.transform.gameObject.GetComponent<PlayerController>().canMove = false;

                
            }
        }

       


    }




}
