using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool alive = true;
    public float moveSpeed;
    public float jumpForce;
    public float forwardSpeed;
    //public Rigidbody theRB;
    public CharacterController controller;

    private Vector3 moveDirection;
    public float gravityScale;

    // Start is called before the first frame update
    void Start()
    {
        //theRB = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!alive) return;
        /*theRB.velocity = new Vector3(Input.GetAxis("Horizontal")* moveSpeed, theRB.velocity.y, Input.GetAxis("Vertical") * moveSpeed);

        if(Input.GetButtonDown("Jump"))
        {
            theRB.velocity = new Vector3(theRB.velocity.x, jumpForce, theRB.velocity.z);
        }*/

        moveDirection = new Vector3(Input.GetAxis("Horizontal")* moveSpeed, moveDirection.y, forwardSpeed);
        if (controller.isGrounded)
        {
            moveDirection.y = 0f;
            if (Input.GetButtonDown("Jump"))
            {
            moveDirection.y = jumpForce;
            }
        }
        

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);

    }

    public void Die ()
    {
        
    }
}