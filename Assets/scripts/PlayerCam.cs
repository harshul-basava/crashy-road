using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;
    Quaternion targetRotation;
    public Transform player;
    public Transform orientation;

    Rigidbody m_Rigidbody;
    private Camera cam;

    float horInp;
    float xRotation;
    float yRotation;

    public GameObject wheel;
    float rotashun;
    int z;
    // Start is called before the first frame update
    void Start()
    {
        //m_Rigidbody = player.GetComponent<Rigidbody>();
        cam = GetComponent<Camera>();
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
        wheel = GameObject.FindWithTag("wheel");
        z = 0;
    }

    void Update() 
    {
        z = GameObject.FindWithTag("button").GetComponent<button>().z;
        //horInp = Input.GetAxisRaw("Horizontal");
        rotashun = wheel.GetComponent<getRot>().rotashin;

        if (z % 3 == 0)
        {
            cam.enabled = true;
        }
        else
        {
            cam.enabled = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * -1 *  sensY;

         yRotation = -127.279217f *  rotashun; //mouseX;
         //Debug.Log(rotashun);
         
         //xRotation += mouseY; 
         //xRotation = Mathf.Clamp(xRotation, -15f, 15f);  

         transform.rotation = Quaternion.Euler(20.37f, yRotation, 0);
         transform.position = new Vector3(player.position.x + (-7.63f * Mathf.Cos((transform.rotation.eulerAngles.y * Mathf.Deg2Rad) - Mathf.PI/2)), transform.position.y, player.position.z + (-7.63f * Mathf.Cos(transform.rotation.eulerAngles.y * Mathf.Deg2Rad)));
         //Debug.Log((3.45f * Mathf.Cos((transform.rotation.eulerAngles.y * Mathf.Deg2Rad) - Mathf.PI/2)));
         //targetRotation = Quaternion.Euler(orientation.rotation.x, orientation.rotation.y + yRotation, orientation.rotation.z);
         //var newRotation = Quaternion.RotateTowards(orientation.rotation, targetRotation, 300f * Time.deltaTime);
         player.rotation = Quaternion.Euler(0, yRotation, 0);
         orientation.rotation = Quaternion.Euler(0, yRotation, 0);
         //m_Rigidbody.MoveRotation(newRotation);
         //orientation.rotation = Quaternion.Euler(0, yRotation, 0);
         //newRotation = Quaternion.Euler(orientation.rotation.x, orientation.rotation.y + yRotation, orientation.rotation.z);
         //orientation.rotation = Quaternion.Slerp(orientation.rotation, newRotation, Time.deltaTime * 10f);
    }
}
