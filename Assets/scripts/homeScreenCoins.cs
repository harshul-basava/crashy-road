using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class homeScreenCoins : MonoBehaviour
{
    GameObject canvas;
    float cw;
    float ch;

    TextMeshProUGUI textBox; 

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.FindWithTag("canvas");
        cw = canvas.GetComponent<RectTransform>().rect.width;
        ch = canvas.GetComponent<RectTransform>().rect.height;

        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(336 - (cw/2), (ch/2) - 115, 0);

        textBox = gameObject.GetComponent<TextMeshProUGUI>();

        if(!PlayerPrefs.HasKey("coinCount"))
        {
            textBox.text = "0";
        }
        else
        {
            textBox.text = PlayerPrefs.GetInt("coinCount").ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {

        cw = canvas.GetComponent<RectTransform>().rect.width;
        ch = canvas.GetComponent<RectTransform>().rect.height;

        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(336 - (cw/2), (ch/2) - 115, 0);

        if(!PlayerPrefs.HasKey("coinCount"))
        {
            textBox.text = "0";
        }
        else
        {
            textBox.text = PlayerPrefs.GetInt("coinCount").ToString();
        }
    }
}
