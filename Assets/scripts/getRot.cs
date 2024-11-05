using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getRot : MonoBehaviour
{
    //Vector3 screenPos;
    Vector3 mousePos;
    Vector3 mouseRelPos;
    [SerializeField]Vector3 forw;
    [SerializeField]Vector3 cForw;

    RectTransform rot;
    public float rotashin;
    [SerializeField]float angle1;
    [SerializeField]float offset;

    GameObject canvas;
    [SerializeField]float deg;
    float cw;
    float ch;

    [SerializeField]float x;
    [SerializeField]float y;
    // Start is called before the first frame update
    void Start()
    {    
        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(266 - (cw/2), 293 - (ch/2), 0);

        x = gameObject.GetComponent<RectTransform>().anchoredPosition.x;
        y = gameObject.GetComponent<RectTransform>().anchoredPosition.y;

        canvas = GameObject.FindWithTag("canvas");
        cw = canvas.GetComponent<RectTransform>().rect.width;
        ch = canvas.GetComponent<RectTransform>().rect.height;

        mousePos = Camera.main.ScreenToWorldPoint(new Vector3( Input.mousePosition.x, Input.mousePosition.y, 1.0f ));
        mousePos.z = 0;

        forw = new Vector3(0, 10, 0);

        rot = gameObject.GetComponent<RectTransform>();        
        rot.rotation = Quaternion.Euler(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        cw = canvas.GetComponent<RectTransform>().rect.width;
        ch = canvas.GetComponent<RectTransform>().rect.height;

        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(266 - (cw/2), 293 - (ch/2), 0);

        x = gameObject.GetComponent<RectTransform>().anchoredPosition.x;
        y = gameObject.GetComponent<RectTransform>().anchoredPosition.y;

        deg = ((transform.rotation.z))*(Mathf.PI/180)*(124.163441f);

        cForw = new Vector3(-Mathf.Sin(deg), Mathf.Cos(deg), 0);

        //mousePos = Camera.main.ScreenToWorldPoint(new Vector3( Input.mousePosition.x, Input.mousePosition.y, 1.0f ));
        if (Input.touchCount > 0)
        {   
            int i = 0; 
            while (i < Input.touchCount)
            {
                Touch touch = Input.GetTouch(i);

                mousePos.z = 0;
                mousePos.x = (cw/2) * (((touch.position.x)/(Screen.width/2)) - 1);
                mousePos.y = (ch/2) * (((touch.position.y)/(Screen.height/2)) - 1);
                
                if (mousePos.x < (x + 500))//(((mousePos.x >= (x - 221) && mousePos.x <= (x - 128)) || (mousePos.x >= (x + 12) && mousePos.x <= (x + 232))) && (mousePos.y >= (y - 223) && mousePos.y <= (y + 217))) || ((mousePos.x >= (x - 221) && mousePos.x <= (x + 232)) && ((mousePos.y <= (y + 217) && mousePos.y >= (y + 92))) || (mousePos.y >= (y - 223) && mousePos.y <= (y - 83))))
                {
                    var realForw = new Vector3 (0, 10, 0);
                    mouseRelPos = mousePos - new Vector3(x, y, 0); 

                    if (!(touch.phase == TouchPhase.Began))
                    {
                        //Debug.Log("AAAAAAAAAAAAAAAA" + counter);
                        //Debug.Log(mousePos.x); //+ "   " + mousePos.y);
                        angle1 = Vector3.Angle(mouseRelPos, forw);

                        if ((mouseRelPos.x - forw.x) > 0)
                        {
                            angle1 = -angle1;
                        }
                        //angle1 = (angle1)/(127.279217f);

                        if (((angle1 + offset) * rot.rotation.z) <= 0 && Mathf.Abs(rot.rotation.z) > 0.65)
                        {
                            //no
                        }
                        else
                        {
                            rot.rotation = Quaternion.Euler(0, 0, Mathf.Clamp(angle1 + offset, -85, 85));                      
                        }

                        rotashin = rot.rotation.z;
                        rotashin = Mathf.Clamp(rotashin, -0.707106801f, 0.707106801f);
                    }
                    else if (touch.phase == TouchPhase.Began)//Input.GetMouseButtonDown(0))
                    {
                        forw = new Vector3(mouseRelPos.x, mouseRelPos.y, 0);
                        
                        deg = ((transform.rotation.z))*(Mathf.PI/180)*(124.163441f);

                        cForw = new Vector3(-Mathf.Sin(deg), Mathf.Cos(deg), 0);

                        offset = Vector3.Angle(cForw, realForw);

                        if (transform.rotation.z < 0)
                        {
                            offset = -offset;
                        }
                    }
                } 

                i++;
            }
        }
        //Debug.Log("we got here" + counter);
    }

    void RotatingWheel() 
    {

    }
}
