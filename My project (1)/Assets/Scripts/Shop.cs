using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameObject interactText;
    public GameObject menu;
    public GameObject sword;
    private bool menuOpen;
    
    public Button button;
    public PlayerMovement playerScript;

    public void Start()
    {
        button.onClick.AddListener(UpgradeSword);
    }

    private void Update()
    {
        if (menuOpen == true)
        {
            menu.SetActive(true);
        }
        else
        {
            menu.SetActive(false);
        }
    }



    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            interactText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                menuOpen = true;

            }
            if (menuOpen == true && Input.GetKeyDown(KeyCode.Escape))
            {
                menuOpen = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            interactText.SetActive(false);
            if (menuOpen == true)
            {
                menuOpen = false;
            }
        }
    }



    void UpgradeSword()
    {
        sword.SetActive(true);
    }
}
