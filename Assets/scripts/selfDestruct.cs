using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfDestruct : MonoBehaviour
{
    bool losing;
    // Start is called before the first frame update
    void Start()
    {
        losing = GameObject.FindWithTag("Player").GetComponent<makingGround>().losingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(losing)
        {
            Destroy(gameObject);
        }
    }
}
