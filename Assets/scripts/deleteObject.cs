using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteObject : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    //public Transform player;
    // Start is called before the first frame update
    void Start()
    {
       player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

         if (player.transform.position.z - gameObject.transform.position.z >= 220) 
        {
             Destroy(gameObject);
        }
    }
}
