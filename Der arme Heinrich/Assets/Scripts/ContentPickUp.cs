using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ContentPickUp : MonoBehaviour {

    public Text pickUpText;
    private bool overPickUp;


    void Start () {
        pickUpText.text = "";
        overPickUp = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            pickUpText.text = "Drücke E um Box aufzuheben.";
            overPickUp = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        pickUpText.text = "";
        overPickUp = false;
    }

    void Update()
    {
        if (overPickUp == true && Input.GetKeyDown(KeyCode.E))
        {
            pickUpText.text = "";
            Destroy(gameObject);
        }
    }
}
