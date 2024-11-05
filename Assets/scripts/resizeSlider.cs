using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resizeSlider : MonoBehaviour
{
    Vector3 size;
    [SerializeField]
    float ch;
    GameObject canvas;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.FindWithTag("canvas");
        ch = canvas.GetComponent<RectTransform>().rect.height;

        player = GameObject.FindWithTag("Player");

        size = gameObject.GetComponent<RectTransform>().localScale;
    }

    // Update is called once per frame
    void Update()
    {
        ch = canvas.GetComponent<RectTransform>().rect.height;
        size = new Vector3(6.62f, 6.62f, 1);
    }
}
