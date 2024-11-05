using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class positioningGOS : MonoBehaviour
{
    GameObject canvas;
    float cw;
    float ch;

    RectTransform rt;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.FindWithTag("canvas");
        cw = canvas.GetComponent<RectTransform>().rect.width;
        ch = canvas.GetComponent<RectTransform>().rect.height;

        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);

        rt = gameObject.GetComponent<RectTransform>();
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, cw);
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, ch);

    }

    // Update is called once per frame
    void Update()
    {
        cw = canvas.GetComponent<RectTransform>().rect.width;
        ch = canvas.GetComponent<RectTransform>().rect.height;

        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);

        rt = gameObject.GetComponent<RectTransform>();
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, cw);
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, ch);
    }
}
