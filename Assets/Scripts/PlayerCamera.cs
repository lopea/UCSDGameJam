using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float Sensitivity = 100.0f;

    private void Start()
    {

        //  Cursor.lockState = CursorLockMode.Locked;
        //hide the mouse
        Cursor.visible = false;

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        
        float mouseY = -Input.GetAxisRaw("Mouse Y");

        if (Vector3.Dot(transform.forward, Vector3.up) < 0.99 && mouseY < 0 || Vector3.Dot(transform.forward, Vector3.up) > -0.99 && mouseY > 0)
            transform.Rotate(mouseY * Vector3.right * Sensitivity * Time.smoothDeltaTime);
        Debug.Log(Mathf.Abs(Vector3.Dot(transform.forward, Vector3.up)));



    }

    
    private void OnDrawGizmos()
    {
        //see the line that represents the view of the player, only seen in the editor.
        Gizmos.DrawLine (transform.position, transform.position + transform.forward * 3.0f);
    }
}
