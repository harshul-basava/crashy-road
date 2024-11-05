using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class button : MonoBehaviour
{
    GameObject canvas;
    float cw;
    float ch;

    TextMeshProUGUI textBox; 
    GameObject player;
    float scoree;
    float timer;

    float a;
    float b;
    public int z;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.FindWithTag("canvas");
        cw = canvas.GetComponent<RectTransform>().rect.width;
        ch = canvas.GetComponent<RectTransform>().rect.height;

        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3((cw/2) - 386, 145 - (ch/2), 0);
    }

    // Update is called once per frame
    void Update()
    {   
        cw = canvas.GetComponent<RectTransform>().rect.width;
        ch = canvas.GetComponent<RectTransform>().rect.height;

        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3((cw/2) - 386, 145 - (ch/2), 0);
    }

    public void changePersp()
    {
        z = z + 1;
    }
}
