using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    private Animator animator;
    private float ySpeed = 0f;
    public float gravity = 0.1f;
    public float jumpForce = 0.05f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible= false;
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        bool wave = Input.GetAxisRaw("Wave") > 0;
        float up = Input.GetAxisRaw("Jump");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        Vector3 moveDir = Vector3.zero;

        animator.SetFloat("inputMagnitude", direction.magnitude);
        animator.SetBool("wave", wave);
        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            
        }
        if (controller.isGrounded)
        {
            ySpeed = 0f;
        }
        animator.SetBool("isOnGround", controller.isGrounded);
        animator.SetFloat("ySpeed", ySpeed);


        if (controller.isGrounded && up > 0)
        {
            ySpeed = jumpForce;
        }

        ySpeed -= gravity * Time.deltaTime;

        










        Vector3 undenemiscamintotal = Vector3.zero;
        undenemiscamintotal = moveDir.normalized * speed * Time.deltaTime;
        undenemiscamintotal.y = ySpeed;
        controller.Move(undenemiscamintotal);
        //print(undenemiscamintotal);

    }
}
