using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ContentPickUp : MonoBehaviour {

    public Text pickUpText;
    private bool overPickUp;
    private bool pickedUp;
    public Texture item;
    private Renderer rend;


    void Start () {
        pickUpText.text = "";
        overPickUp = false;
        pickedUp = false;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && pickedUp == false)
        {
            pickUpText.text = "Drücke E um Box aufzuheben.";
            overPickUp = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        pickUpText.text = "";
        overPickUp = true;
    }

    void Update()
    {
        if (overPickUp == true && Input.GetKeyDown(KeyCode.E))
        {
            pickUpText.text = "";
            pickedUp = true;
            rend.enabled = false;
        }
    }

    void OnGUI()
    {
        if (pickedUp == true)
        {
            GUI.DrawTexture(new Rect(10, 10, 50, 50), item);
        }
    }
}
