using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float Sensitivity = 100.0f;
    public float ViewAngle = 45.0f;


    float rotationX = 0.0f;

    private void Start()
    {

        //  Cursor.lockState = CursorLockMode.Locked;
        //hide the mouse
        Cursor.visible = false;

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {

        //check for mouse movement
        float delta = -Input.GetAxisRaw("Mouse Y") * Sensitivity * Time.deltaTime;

        //if there is mouse movement
        if (Mathf.Abs(delta) > 0.01f)
        {
            //add mouse movement for the x-axis rotation
            rotationX += delta;
            rotationX = Mathf.Clamp(rotationX, -ViewAngle, ViewAngle);

            //set the new rotation value
            transform.rotation = Quaternion.Euler(rotationX, transform.rotation.eulerAngles.y, transform.eulerAngles.z);
        }


    }


    private void OnDrawGizmos()
    {
        //see the line that represents the view of the player, only seen in the editor.
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * 3.0f);
    }
}
