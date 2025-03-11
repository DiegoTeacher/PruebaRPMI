using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator animator;
    private PlayerMovement_RB playerMovement_RB;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement_RB = GetComponent<PlayerMovement_RB>();
    }

    // Update is called once per frame
    void Update()
    {
        //float x = Input.GetAxis("Horizontal");
        //float z = Input.GetAxis("Vertical");
        //bool shiftPressed = Input.GetKey(KeyCode.LeftShift);

        //if(x != 0 || z != 0)
        //{
        //    // se esta moviendo
        //    if(shiftPressed) 
        //    {
        //        // y ademas esta corriendo
        //        animator.SetBool("isRunning", true);
        //        animator.SetBool("isWalking", false);
        //    }
        //    else
        //    {
        //        // y ademas esta andando
        //        animator.SetBool("isRunning", false);
        //        animator.SetBool("isWalking", true);
        //    }
        //}
        //else 
        //{
        //    // esta quieto
        //    animator.SetBool("isRunning", false);
        //    animator.SetBool("isWalking", false);
        //}
    }

    private void LateUpdate()
    {
        animator.SetFloat("Speed",
            playerMovement_RB.GetCurrentSpeed() / playerMovement_RB.runningSpeed);
        // animator.SetFloat("Speed", playerMovement_RB.GetComponent<Rigidbody>().velocity.magnitude / playerMovement_RB.runningSpeed);
    }

}
