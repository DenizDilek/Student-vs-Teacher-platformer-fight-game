using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController2D controller ;
    float horizontalmovement;
    public float Speed;
    public bool isDying = false;
    bool Jump = false;
    bool crouch = false;
    public Animator animator;
    
    // Update is called once per frame
    void Update()
    {
        horizontalmovement = Input.GetAxisRaw("Horizontal") * Speed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalmovement));
        if (Input.GetButtonDown("Jump"))
        {
            Jump = true;
            animator.SetBool("isJumping", true);
        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch")) {
            crouch = false;
        }
        if(GameManager.isDead == true)
        {
            
            StartCoroutine(Die());
        }
    }
    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }
    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("isCrouching", isCrouching);
    }
    void FixedUpdate()
    {
        controller.Move(horizontalmovement * Time.fixedDeltaTime, crouch, Jump);
        Jump = false;
    }
    IEnumerator Die()
    {
        animator.SetBool("isDying",true);
        yield return new WaitForSeconds(5);
        

    }
}
