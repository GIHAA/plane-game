using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planecontoller : MonoBehaviour
{
    
    public Joystick joystick;

    public float forwardspeed = 15f;
    public float horizontalspeed = 4f;
    public float verticalspeed = 4f;

    public float maxhorizontalrotation = 0.5f;
    public float maxverticalrotation = 0.06f;
    public float smothness = 5f;
    public float rotationsmoothness = 5;

    private Rigidbody rb;

    private float horizontalInput;
    private float verticalInput;

    private float speedmultiplier = 1000f;

    private float forwardspeedmultiplier = 100f;
    void Start()
    {
        rb =  GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update(){

        if(Input.GetMouseButton(0) || Input.touches.Length != 0){

            horizontalInput = joystick.Horizontal;
            verticalInput = joystick.Vertical;

        }else{

            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw( "Vertical");
        }

        handlerotation();
    }

    private void FixedUpdate(){
        
       handleplanemovement();
    }

    private void handleplanemovement(){

        rb.velocity = new Vector3(
            rb.velocity.x,
            rb.velocity.y,
            forwardspeed * forwardspeedmultiplier * Time.deltaTime
        );

        float xvelocity = horizontalInput*speedmultiplier * horizontalspeed * Time.deltaTime;
        float yvelocity = -verticalInput*speedmultiplier * verticalspeed * Time.deltaTime;

        rb.velocity = Vector3.Lerp(
            rb.velocity,
            new Vector3(xvelocity,yvelocity,rb.velocity.z),
            Time.deltaTime*smothness

        );
    }

    private void handlerotation(){

        float horizontalrotation = horizontalInput*maxhorizontalrotation;
        float verticalrotation = verticalInput*maxverticalrotation;

        transform.rotation = Quaternion.Lerp(

            transform.rotation,
            new Quaternion(

                verticalrotation,
                transform.rotation.y,
                -horizontalrotation,
                transform.rotation.w

            ),
            Time.deltaTime*rotationsmoothness
        );

    }
}
