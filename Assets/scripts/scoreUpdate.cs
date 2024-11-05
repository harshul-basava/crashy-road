using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreUpdate : MonoBehaviour
{
    GameObject canvas;
    float cw;
    float ch;

    TextMeshProUGUI textBox; 
    public GameObject player;
    int scoree;
    
    bool yes;

    // Start is called before the first frame update
    void Start()
    {
        yes = true;
        canvas = GameObject.FindWithTag("canvas");
        cw = canvas.GetComponent<RectTransform>().rect.width;
        ch = canvas.GetComponent<RectTransform>().rect.height;

        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(406 - (cw/2), (ch/2) - 190, 0);

        textBox = gameObject.GetComponent<TextMeshProUGUI>();
        player = GameObject.FindWithTag("Player");
        textBox.text = "0";
    }

    // Update is called once per frame
    void Update()
    {

        cw = canvas.GetComponent<RectTransform>().rect.width;
        ch = canvas.GetComponent<RectTransform>().rect.height;

        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(406 - (cw/2), (ch/2) - 190, 0);

        scoree = player.GetComponent<PlayerMovement>().score;
        textBox.text = "" + scoree;

        if (player.GetComponent<makingGround>().gameOver && yes)
        {
            PlayerPrefs.SetInt("coinCount", PlayerPrefs.GetInt("coinCount") + scoree);
            yes = false;
        }
    }
}
