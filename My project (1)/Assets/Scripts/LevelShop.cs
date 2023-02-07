using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelShop : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Application.LoadLevel(0);
        }
    }
}
