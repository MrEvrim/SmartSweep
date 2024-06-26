using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Waypoint2 : MonoBehaviour
{
    public Image img;
    public Transform target;
    public Text mesafe;
    public Vector3 offset;
    void Update()
    {
        float minX = img.GetPixelAdjustedRect().width/2;
        float maxX = Screen.width - minX;

        float minY = img.GetPixelAdjustedRect().width / 2;
        float maxY = Screen.height - minY;

        Vector2 pos = Camera.main.WorldToScreenPoint(target.position+offset);

        if (Vector3.Dot((target.position - transform.position), transform.forward) < 0)
        {
            if (pos.x < Screen.width / 2)
            {
                pos.x = maxX;
            }
            else
            {
                pos.x = minX;
            }
        }

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.x, minY, maxY);

        img.transform.position = pos;
        mesafe.text = ((int)Vector3.Distance(target.position, transform.position)).ToString()+"m";
    }
}
