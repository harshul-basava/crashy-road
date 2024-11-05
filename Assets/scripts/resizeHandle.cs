using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resizeHandle : MonoBehaviour
{
    Vector3 size;
    // Start is called before the first frame update
    void Start()
    {
        size = gameObject.GetComponent<RectTransform>().localScale;
    }

    // Update is called once per frame
    void Update()
    {
        size = new Vector3(1.09f, 0.55f, 1f);
    }
}
