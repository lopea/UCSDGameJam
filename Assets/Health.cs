using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    float curr = 7;
    float max = 7;
    bool isDirty = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (curr < max)
            {
                curr += 1;
                isDirty = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (curr > 0)
            {
                curr -= 1;
                isDirty = true;
            }
        }

        if (isDirty)
        {
            transform.localScale = new Vector3(curr/max, 1, 1);
            isDirty = false;
        }
    }
}
