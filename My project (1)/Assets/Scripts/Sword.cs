using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private Animator anim;


    private void Start()
    {
        anim = GetComponentInParent<Animator>();
    }
    public void Update()
    {
        MeleeCombat();
    }
    public void MeleeCombat()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetTrigger("isAttacking");
        }
    }
}
