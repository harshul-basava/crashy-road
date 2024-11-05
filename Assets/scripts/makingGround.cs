using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makingGround : MonoBehaviour
{
    float a;
    float d;
    
    int n;
    int m;
    int z;

    float b;
    float c;

    float e;
    float f;

    public GameObject empty;
    Quaternion rot;
    public GameObject coin;
    public GameObject gameOverScreen;

    public GameObject enemy;
    public GameObject fakeEnemy;
    public GameObject emptyEn;
    public GameObject crasher;

    public bool losingHealth;
    public int health;
    float timer;

    public bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen.SetActive(false);
        gameOver = false;
        health = 1;
        losingHealth = false;
        timer = 0;

        rot = transform.rotation;
        a = gameObject.transform.position.z;
        b = 0;
        c = gameObject.transform.position.z;
        d = 0;
        e = gameObject.transform.position.z;
        f = 0;

        n = 0;
        m = 0;
        z = 0;
        //making initial ground blocks
        GameObject empty0 = Instantiate(empty, transform.position + new Vector3(0, -1, 0), transform.rotation) as GameObject;
        GameObject empty1 = Instantiate(empty, transform.position + new Vector3(0, -1, 110), transform.rotation) as GameObject;
        GameObject empty3 = Instantiate(empty, transform.position + new Vector3(0, -1, 220), transform.rotation) as GameObject;
        GameObject empty4 = Instantiate(empty, transform.position + new Vector3(0, -1, 330), transform.rotation) as GameObject;
        //making initial coins, enemies, and crashers
        
        SpawnEnemies();

        while (m < 3) {
            SpawnCoins();
            m++;
        }
        m = m - 1;

        GameObject crasher0 = Instantiate(crasher, new Vector3(Random.Range(-2, 3) * 20.0f, 4f, 40), rot) as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(losingHealth == true && timer < 6)
        {
            timer = timer + Time.deltaTime;
        }
        else if(losingHealth == true && timer >= 6)
        {
            losingHealth = false;
            timer = 0;
            SpawnEnemies();
        }

        //spawning more ground
        b = gameObject.transform.position.z - a;
        d = gameObject.transform.position.z - c;
        f = gameObject.transform.position.z - e;

        if (b >= 100) {
            m++;
            SpawnCoins();
            a = gameObject.transform.position.z;
            b = 0;
        }

        if (d >= 110) {
            n++;
            GameObject nextGround = Instantiate(empty, new Vector3(0, 0, 310 + (110*n)), rot) as GameObject;

            c = gameObject.transform.position.z;
            d = 0;
        }

        if (f >= 300) {
            z++;
            GameObject crasher1 = Instantiate(crasher, new Vector3(Random.Range(-2, 3) * 20.0f, 4f, 80 + (300*z)), rot) as GameObject;
            e = gameObject.transform.position.z;
            f = 0;
        }

        if (health == 0)
        {
            gameOver = true;
            gameOverScreen.SetActive(true);
            
        }
    }

    void SpawnCoins() 
    {
        //function for spawning coins
        for (int i = 50; i <= 100; i = i + 50) 
            {
            GameObject nextCoin1 = Instantiate(coin, new Vector3(Random.Range(-2, 3) * 20.0f, -1.5f, -20 + (100*m) + i), rot) as GameObject;
            }
    }

    void SpawnEnemies() 
    { 
        for (int i = 0; i <= 150; i = i + 75) 
        {
            List<int> nums = new List<int>();
            nums.Add(-2);
            nums.Add(-1);
            nums.Add(0);
            nums.Add(1);
            nums.Add(2);

            var q = Random.Range(-2, 3);

            if (i == 150)
            {
                foreach(int j in nums)
                {
                    if(j == q)
                    {
                        GameObject nextEnemies = Instantiate(enemy, new Vector3(j * 20.0f, 3.0f, gameObject.transform.position.z + 80 + i), rot) as GameObject; 
                    }
                    else
                    {
                        GameObject nextEnemies = Instantiate(emptyEn, new Vector3(j * 20.0f, 3.0f, gameObject.transform.position.z + 80 + i), rot) as GameObject; 
                    }
                }
            }
            else
            {
                foreach(int j in nums)
                {
                    if(j == q)
                    {
                        GameObject nextEnemies = Instantiate(fakeEnemy, new Vector3(j * 20.0f, 3.0f, gameObject.transform.position.z + 80 + i), rot) as GameObject; 
                    }
                }
            }
        }
    }


    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "ew" && losingHealth == false) 
        {
            losingHealth = true;
            health = health - 1;
        }
    }
}
