using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scrap : MonoBehaviour
{
    public float scrapCount = 0f;
    public TextMeshProUGUI tmpScrap;

    


    private void Update()
    {
        tmpScrap.SetText(scrapCount + "");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Scrap")
        {
            scrapCount += 10;
            Destroy(other.gameObject);
        }
    }
}
