using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class healthUpdate : MonoBehaviour
{
    GameObject canvas;
    float cw;
    float ch;

    TextMeshProUGUI textBox; 
    public GameObject player;
    int scoree;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.FindWithTag("canvas");
        cw = canvas.GetComponent<RectTransform>().rect.width;
        ch = canvas.GetComponent<RectTransform>().rect.height;

        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(406 - (cw/2), (ch/2) - 316, 0);

        textBox = gameObject.GetComponent<TextMeshProUGUI>();
        player = GameObject.FindWithTag("Player");
        textBox.text = "6";
    }

    // Update is called once per frame
    void Update()
    {

        cw = canvas.GetComponent<RectTransform>().rect.width;
        ch = canvas.GetComponent<RectTransform>().rect.height;

        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(406 - (cw/2), (ch/2) - 316, 0);

        scoree = player.GetComponent<makingGround>().health;
        textBox.text = "" + scoree;
    }
}
