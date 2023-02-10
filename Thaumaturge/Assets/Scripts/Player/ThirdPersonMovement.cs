using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    [Header("References")]
    public CharacterController controller;
    public Transform cam;

    [Header("Movement")]
    public float speed;
    public float turnSmoothTime;
    public float spritingMultipler;

    [Header("Jumping")]
    public float gravity = -20f;
    public float jumpSpeed = 15;

    [Header("Private References")]
    float turnSmoothVelocity;
    Vector3 moveVelocity;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        PlayerMovement();
    }

    public void PlayerMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        if (controller.isGrounded)
        {
            // Player movement
            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f); 

                Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                controller.Move(moveDirection.normalized * speed * Time.deltaTime);

                // Player will sprint while holding shift
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    controller.Move(moveDirection.normalized * spritingMultipler * Time.deltaTime);
                }
            }

            // Player jumps
            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveVelocity.y = jumpSpeed;
            }
        }

        // Adding gravity
        moveVelocity.y += gravity * Time.deltaTime;
        controller.Move(moveVelocity * Time.deltaTime);
    }
}