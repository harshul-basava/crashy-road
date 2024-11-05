using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    public int score;

    GameObject slider1;
    public float moveSpeed;

    public float groundDrag;

    public float playerHeight;
    public LayerMask ground;
    bool grounded;

    public Transform orientation;
    public Transform player;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirectionForw; 
    Vector3 moveDirectionHori; 
    float error;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 4;
        score = 0;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        slider1 = GameObject.FindWithTag("slider");
    }

    // Update is called once per frame
    void Update()
    {
        moveSpeed = slider1.GetComponent<Slider>().value;
        //grounded check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f, ground);

        MyInput();

        //handling drag
        if (grounded)
            rb.drag = groundDrag;
        else 
            rb.drag = 0;
    }

    private void FixedUpdate() 
    {
        MovePlayer();
    }

    private void MyInput() {
        
        //horizontalInput = Input.GetAxisRaw("Horizontal");
        //verticalInput = Input.GetAxisRaw("Vertical");
        //horizontalInput = 0;
    }

    private void MovePlayer() {
        
        moveDirectionForw = orientation.forward; //* verticalInput; //+ orientation.right * horizontalInput;
        rb.AddForce(moveDirectionForw.normalized * moveSpeed * 10f, ForceMode.Force);

        // moveDirectionHori = orientation.right * horizontalInput; 
        // if (Mathf.Abs(player.position.x) >= 15 && (player.position.x/horizontalInput) > 0) {
        //     error = (20 - Mathf.Abs(player.position.x))/5;
        //     rb.AddForce(moveDirectionHori.normalized * error * moveSpeed * 10f, ForceMode.Force);
        // } 
        
        // else { 
        //     rb.AddForce(moveDirectionHori.normalized * moveSpeed * 10f, ForceMode.Force);
        // }

        // var pos = player.position;
        // pos.x =  Mathf.Clamp(player.position.x, -20f, 20f);
        // player.position = pos;
    }
}