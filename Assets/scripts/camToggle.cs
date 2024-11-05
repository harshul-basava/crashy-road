using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camToggle : MonoBehaviour
{

    private Camera cam;
    int z;
    // Start is called before the first frame update
    void Start()
    {
        z = 2;
        cam = GetComponent<Camera>();
        cam.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        z = GameObject.FindWithTag("button").GetComponent<button>().z + 2;
        if (Input.GetKeyDown(KeyCode.R))
         {
            z = z + 1;
         }
        
        if (z % 3 == 0)
        {
            cam.enabled = true;
        }
        else
        {
            cam.enabled = false;
        }
    }
}

