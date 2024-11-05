using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public GameObject en;
    public GameObject empty;
    int score;
    
    float a;
    float b;
    
    float c;
    float d;

    int dist;
    public int reps;

    public GameObject pl;

    Quaternion rot;

    bool spawning;

    bool losing;
    float timer;
    float t;

    // Start is called before the first frame update
    void Start()
    {   
        spawning = true;
        rot = transform.rotation;

        a = gameObject.transform.position.z;
        b = 0;
        
        pl = GameObject.FindWithTag("Player");
        
        c = pl.transform.position.z;
        d = 0;
        
        dist = 75;
        reps = 4;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {   
        losing = pl.GetComponent<makingGround>().losingHealth;
        score = pl.GetComponent<PlayerMovement>().score;

        if (losing == true && timer <= 2 && gameObject.CompareTag("ew"))
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            timer = timer + Time.deltaTime;
            t = (2 - timer)/2;
            gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0.0f, t);
        }
        else if (losing == true && timer <= 2)
        {
            timer = timer + Time.deltaTime;
            t = (2 - timer)/2;
        
        }
        else if (losing == true && timer >= 2)
        {
            Destroy(gameObject);
        }
        

        if (score >= 5 && score < 10)
        {
            reps = 3;
        }
        else if (score >= 10 && score < 15)
        {
            reps = 2;
        }
        else if (score >= 15)
        {
            reps = 1;
        }

        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.25f);

        b = gameObject.transform.position.z - a;
        d = pl.transform.position.z - c;
        if ((b - d) <= (dist*-1) && spawning && gameObject.transform.position.x == 0 && losing == false) {
            SpawnEnemies();
            spawning = false;
        }

        if (gameObject.transform.position.z < pl.transform.position.z - 15)
        {
            Destroy(gameObject);
        }

    }

    void SpawnEnemies() 
    {  
        List<int> ogNums = new List<int>();
        ogNums.Add(-2);
        ogNums.Add(-1);
        ogNums.Add(0);
        ogNums.Add(1);
        ogNums.Add(2);

        List<int> nums = new List<int>();
        nums.Add(-2);
        nums.Add(-1);
        nums.Add(0);
        nums.Add(1);
        nums.Add(2);

        var i = 0;
        while (i < reps)
        {
            var n = Random.Range(0, (5 - i));
            nums.RemoveAt(n);
            i = i + 1;
        }

        foreach(int j in ogNums)
        {

            var y = false;
            foreach(int p in nums)
            {
                if (j == p)
                {
                    y = true;
                    break;
                }
            }

            if(y)
            {
                GameObject nextEnemies = Instantiate(en, new Vector3(j * 20.0f, 3.0f, gameObject.transform.position.z + dist), rot) as GameObject; 
            }
            else
            {
                GameObject nextEnemies = Instantiate(empty, new Vector3(j * 20.0f, 3.0f, gameObject.transform.position.z + dist), rot) as GameObject; 
            }
        }
        //Debug.Log("Spawning");
    }
}
