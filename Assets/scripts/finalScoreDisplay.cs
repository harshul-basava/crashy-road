using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class finalScoreDisplay : MonoBehaviour
{
    TextMeshProUGUI textBox; 
    GameObject player;
    public GameObject scoreDisplay;
    float scoree;
    bool display;
    int m;
    // Start is called before the first frame update
    void Start()
    {
        textBox = gameObject.GetComponent<TextMeshProUGUI>();
        player = GameObject.FindWithTag("Player");
        m = 0;
    }

    // Update is called once per frame
    void Update()
    {
        display = player.GetComponent<makingGround>().gameOver;

        if (display && m == 0)
        {
            scoree = Mathf.Round(scoreDisplay.GetComponent<scUp>().scoree);
            if (scoree > PlayerPrefs.GetInt("hs"))
            {
                PlayerPrefs.SetInt("hs", (int) scoree);
                PlayerPrefs.Save();
            }
            textBox.text = "High Score: " + PlayerPrefs.GetInt("hs").ToString();
            m = 1;
        }
    }
}
