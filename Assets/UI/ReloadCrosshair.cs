using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadCrosshair : MonoBehaviour
{
    Vector3 temp = new Vector3(1, 1, 1);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            //transform.localScale = new Vector3(3, 3, 1);
            transform.Rotate(0, 0, -1);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            temp = transform.localScale;
            temp.x += .2f;
            temp.y += .2f;

            transform.localScale = temp;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            temp = transform.localScale;
            temp.x -= .2f;
            temp.y -= .2f;

            transform.localScale = temp;
        }
    }
}
