using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{

    /// <summary>
    /// The Current Speed of the player
    /// </summary>
    [SerializeField]
    private float _Speed = 5.0f;

    /// <summary>
    /// Gravity of the player.
    /// </summary>
    [SerializeField]
    private float _Gravity = 20.0f;

    [SerializeField]
    private float _JumpHeight = 15.0f;

    [SerializeField]
    private float _JumpStrafeMultiplier = 0.5f;

    /// <summary>
    /// Unity's controller System
    /// </summary>
    private CharacterController controller;

    private Vector3 playerVelocity = Vector3.zero;

    private bool isJumping = false;

    private PlayerCamera _viewCamera;

    // Start is called before the first frame update
    void Start()
    {

        //Get the character controller from this gameObject
        controller = GetComponent<CharacterController>();

        //Get the camera that is this object is a parent to.
        _viewCamera = GetComponentInChildren<PlayerCamera>();

        //check if there is no camera in the children
        if (!_viewCamera)
        {
            Debug.LogError("There is no camera on the player!!!!! Please add a camera object as a child to the player object!!!!");
        }
    }
    private void Awake()
    {
        _viewCamera = GetComponentInChildren<PlayerCamera>();
        _viewCamera.transform.forward = transform.forward;
    }
    // Update is called once per frame
    void Update()
    {
        bool isGrounded = controller.isGrounded;
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //dont apply gravity if the player is grounded
        if (isGrounded && playerVelocity.y < 0)
            playerVelocity.y = 0;

        

        //if the player is currently on the floor
        if (isGrounded)
        {
            //Get the status of the current input
            playerVelocity = input * _Speed;

            //apply jumping
            if (Input.GetButton("Jump"))
            {
                playerVelocity.y = _JumpHeight;
            }
            playerVelocity = transform.TransformDirection(playerVelocity);
        }
        else
        {
            float yValue = playerVelocity.y;
            //Get the status of the current input
            playerVelocity = input * _Speed * _JumpStrafeMultiplier;
            playerVelocity = transform.TransformDirection(playerVelocity);
            playerVelocity.y = yValue;
            //apply gravity
            playerVelocity.y -= _Gravity * Time.deltaTime;
        }

        //apply rotation



        //apply velocity to the player
        controller.Move(playerVelocity * Time.deltaTime);

    }
    private void LateUpdate()
    {
        transform.Rotate(0, Input.GetAxisRaw("Mouse X") * Time.deltaTime * _viewCamera.Sensitivity, 0);

    }

}
