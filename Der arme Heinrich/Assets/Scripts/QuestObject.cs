using UnityEngine;
using System.Collections;

public class QuestObject : MonoBehaviour {

    public int questNumber;

    public QuestManager theQM;

    //public string startText;
    //public string endText;

    public bool isItemQuest;
    public string targetItem;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(isItemQuest)
        {
            if(theQM.itemCollected == targetItem)
            {
                theQM.itemCollected = null;
                EndQuest();
            }
        }
	
	}

    public void StartQuest()
    {   

        //theQM.ShowQuestText(startText);        
    }

    public void EndQuest()
    {
        //theQM.ShowQuestText(endText);
        theQM.anzahlCompleted++;
        theQM.questCompleted[questNumber] = true;
        gameObject.SetActive(false);
    }
}
