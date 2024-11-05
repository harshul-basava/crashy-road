using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collect : MonoBehaviour
{
    
    public GameObject player;

    void Start() 
    {
        player = GameObject.FindWithTag("Player");
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "gameobj") 
        {
            if (!player.GetComponent<makingGround>().gameOver)
            {
                player.GetComponent<PlayerMovement>().score++;
            }
            Destroy(gameObject);
        }
    }

    void Update() 
    {
        if (player.transform.position.z - gameObject.transform.position.z > 15)
        {
            Destroy(gameObject);
        }
    }
}