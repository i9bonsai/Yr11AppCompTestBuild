using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rig;
    public float jumpForce;

    private bool isGrounded;

    // Start is called before the first frame update
    //void Start()
    //{  
    //}

    // Update is called once per frame
    void Update()

    {
        //Get the horizontal and vertical inputs
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        //Set our velocity based on our inputs
        rig.velocity = new Vector3(x, rig.velocity.y, z);

        //Create a copy of our velocity variable and
        //Set the Y-axis to be 0
        Vector3 vel = rig.velocity;
        vel.y = 0;

        //If we're moving, rotate to face our moving direction
        if(vel.x != 0 || vel.z != 0)
        {
        transform.forward = vel;
            
        }

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {   
            isGrounded = false;
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.contacts[0].normal == Vector3.up)
        {
            isGrounded = true;

        }


    }

}


