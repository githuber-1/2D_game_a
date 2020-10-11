using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroAnim : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        HandleRunning();
        HandleJumping();
    }

    private void HandleRunning()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }
    private void HandleJumping()
    {
        
    }
}
