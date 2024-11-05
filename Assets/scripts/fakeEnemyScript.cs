using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fakeEnemyScript : MonoBehaviour
{
    public GameObject pl;
    bool losing;
    float timer;
    float dimer;
    float t;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0.0f, 0.0f);
        pl = GameObject.FindWithTag("Player");
        timer = 0;
        dimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (dimer <= 1)
        {
            dimer = dimer + Time.deltaTime;
            gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0.0f, dimer);
        }

        losing = pl.GetComponent<makingGround>().losingHealth;

        if (losing == true && timer <= 2)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            timer = timer + Time.deltaTime;
            t = (2 - timer)/2;
            gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0.0f, t);
        }
        else if (losing == true && timer >= 2)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0.0f, 0.0f);
            Destroy(gameObject);
        }

        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.25f);

        if (gameObject.transform.position.z < pl.transform.position.z - 15)
        {
            Destroy(gameObject);
        }
    }
}
