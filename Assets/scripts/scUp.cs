using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scUp : MonoBehaviour
{
    GameObject canvas;
    float cw;
    float ch;

    TextMeshProUGUI textBox; 
    GameObject player;
    public float scoree;
    float timer;

    float a;
    float b;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.FindWithTag("canvas");
        player = GameObject.FindWithTag("Player");
        cw = canvas.GetComponent<RectTransform>().rect.width;
        ch = canvas.GetComponent<RectTransform>().rect.height;

        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(290 - (cw/2), (ch/2) - 81, 0);

        textBox = gameObject.GetComponent<TextMeshProUGUI>();
        textBox.text = "Score: 0";

        a = player.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        b = player.transform.position.z;
        cw = canvas.GetComponent<RectTransform>().rect.width;
        ch = canvas.GetComponent<RectTransform>().rect.height;

        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(290 - (cw/2), (ch/2) - 81, 0);
        timer = b - a;
        if (!player.GetComponent<makingGround>().gameOver)
        {
            scoree = Mathf.Round(timer*10f)/100f;
        }
        textBox.text = "Score: " + scoree;
    }
}
