using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crashDetection : MonoBehaviour
{
    
    public GameObject player;
    public float speed;
    float dimer;

    void Start() 
    {
        player = GameObject.FindWithTag("Player");

        speed = 0.5f;

        if (gameObject.transform.position.x > 0)
        {
            speed = speed * -1;
        }

        gameObject.GetComponent<Renderer>().material.color = new Color(gameObject.GetComponent<Renderer>().material.color.r, gameObject.GetComponent<Renderer>().material.color.g, gameObject.GetComponent<Renderer>().material.color.b, 0.0f);
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "gameobj") 
        {
            player.GetComponent<PlayerMovement>().score = player.GetComponent<PlayerMovement>().score + 5;
            Destroy(gameObject);
        }
    }

    void Update() 
    {
        if (dimer <= 1)
        {
            dimer = dimer + Time.deltaTime;
            gameObject.GetComponent<Renderer>().material.color = new Color(gameObject.GetComponent<Renderer>().material.color.r, gameObject.GetComponent<Renderer>().material.color.g, gameObject.GetComponent<Renderer>().material.color.b, dimer);
        }

        gameObject.transform.position = new Vector3 (gameObject.transform.position.x + speed, gameObject.transform.position.y,gameObject.transform.position.z);

        if(Mathf.Abs(gameObject.transform.position.x) >= 45)
        {
            speed = speed * -1;
        }

        if (player.transform.position.z - gameObject.transform.position.z > 15)
        {
            Destroy(gameObject);
        }
    }
}
