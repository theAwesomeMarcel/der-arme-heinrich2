using UnityEngine;
using System.Collections;

public class QuestItem : MonoBehaviour {

    public Texture item;

    public int questNumber;

    private QuestManager theQM;

    public string itemName;

	// Use this for initialization
	void Start () {
        theQM = FindObjectOfType<QuestManager>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player" && Input.GetKeyDown(KeyCode.Space))
        {
            
                if (!theQM.questCompleted[questNumber] && theQM.quests[questNumber].gameObject.activeSelf)
                {
                    theQM.itemCollected = itemName;
                    theQM.questCompleted[questNumber] = true;
                    gameObject.SetActive(false);
                }
            
        }
    }


}
