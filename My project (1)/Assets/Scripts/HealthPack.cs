using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    private PlayerStats playerStats;


    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
    }

}
