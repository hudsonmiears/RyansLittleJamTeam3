using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2D : MonoBehaviour
{

    //private Rigidbody body;
    public float force = 1;
    private Vector3 curVel;
    private float curSpeed;
    public float maxSpeed = 5;
    public Vector3 input;
    CharacterController characterController;

    public static Vector3 XZ = new Vector3(1, 0, 1);
    // Start is called before the first frame update
    void Start()
    {
        //body = GetComponent<Rigidbody>(); 
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        if (input.x > 0)
        {
            this.transform.rotation = Quaternion.identity;
        }
        else if (input.x < 0) {
            this.transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        //curVel += force * input.normalized;
        //if (curVel.magnitude > maxSpeed) curVel = curVel.normalized * maxSpeed;
        //else if (curVel.magnitude < -maxSpeed) curVel = curVel.normalized * -maxSpeed;
        
        //if (input.magnitude == 0) {
        //    curVel += curVel.normalized * force * -3;
        //}

        //if (input.x == 0)
        //{
        //    if (curSpeed > 0)
        //    {
        //        curSpeed -= force*3;
        //    }
        //    else if (curSpeed < 0) {
        //        curSpeed += force*3;
        //    }
        //}

        //curSpeed += force * input.x;
        //if (curSpeed > maxSpeed) curSpeed = maxSpeed;
        //else if (curSpeed < -maxSpeed) curSpeed = -maxSpeed;
        //this.transform.position += input * speed * Time.deltaTime;
        characterController.SimpleMove(input.normalized * force);
    }

    void FixedUpdate() {
        //this.body.AddForce(curVel * Time.fixedDeltaTime);
    }
}
