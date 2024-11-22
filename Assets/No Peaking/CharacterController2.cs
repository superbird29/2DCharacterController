using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2 : MonoBehaviour
{
    [SerializeField] float MovementDirection;
    [SerializeField] float Speed = 8;
    [SerializeField] float JumpStrength = 60;
    [SerializeField] float DashStrength = 20;
    [SerializeField] bool DoubleJumped = true;
    [SerializeField] bool CanDash = true;
    [SerializeField] bool IsDashing = false;


    [SerializeField] Rigidbody2D Rigidbody;
    [SerializeField] Transform GroundCheck;
    [SerializeField] LayerMask Ground;

    void Update()
    {
        MovementDirection = Input.GetAxis("Horizontal");

        ////looks for The a or b button
        ////Downsides: doesnt slow down very quickly, Difficult to allow for change of key code , more basic   
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    Rigidbody.velocity = new Vector2(-1 * Speed, Rigidbody.velocity.y);
        //}
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    Rigidbody.velocity = new Vector2(1 * Speed, Rigidbody.velocity.y);
        //}
        //
        if (Input.GetButtonDown("Jump") && (CheckGround() || DoubleJumped)) 
        {
            print(Input.GetButtonDown("Jump"));
            //Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, JumpStrength);
            Rigidbody.AddForce(transform.up * JumpStrength, ForceMode2D.Impulse);
            //if(!CheckGround())
            //{
                DoubleJumped = false;
            //}
        }

        if(Input.GetButtonDown("Dash") && CanDash)
        {
            StartCoroutine(Dash());
            //Rigidbody.AddForce(Direction() * 60, ForceMode2D.Impulse); Why doesnt this work
        }
        CheckGround();
    }
    void FixedUpdate()
    {
        if(IsDashing)
        {
            return;
        }
        Rigidbody.velocity = new Vector2(MovementDirection * Speed, Rigidbody.velocity.y);
    }

    bool CheckGround()
    {
        //check if the transform groundcheck is touching the ground
        if(Physics2D.OverlapCircle(GroundCheck.position, .25f, Ground))
        {
            DoubleJumped = true;
            return true;
        }
        return false;
    }

    int Direction()
    {
        if(MovementDirection > 0)
        {
            return 1;
        }
        if(MovementDirection < 0)
        {
            return -1;
        }
        return 0;
    }
    IEnumerator Dash()
    {
        CanDash = false;
        IsDashing = true;
        Rigidbody.gravityScale = 0;
        Rigidbody.velocity = new Vector2(Direction() * DashStrength, 0f);  //wont work unless we change the fixed update
        yield return new WaitForSeconds(.5f);
        Rigidbody.gravityScale = 1;
        IsDashing = false;
        CanDash = true;
    }
}
