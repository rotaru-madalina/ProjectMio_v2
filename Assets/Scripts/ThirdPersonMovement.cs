using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    private const int INTERACT_RANGE = 3;
    public CharacterController controller;
    public Transform cam;

    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    private Animator animator;
    private float ySpeed = 0f;
    public float gravity = 0.1f;
    public float jumpForce = 0.05f;
    public LayerMask mask;

    private EventInteractionable latestActiveInteractionable;


    private EventInteractionable activeInteractionable;

    private void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible= false;
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        HandleMovement();

        latestActiveInteractionable?.pressFToInteract.SetActive(false);

        Collider[] interactionables = Physics.OverlapSphere(transform.position, INTERACT_RANGE, mask);
        List<Collider> enabledInteractionables = new List<Collider>();

        if (interactionables.Length <= 0)        
            activeInteractionable = null;        
        else
        {
            foreach (Collider interactionable in interactionables)
            {
                EventInteractionable eventInteractionable = interactionable.GetComponent<EventInteractionable>();
                if (eventInteractionable.enabled)
                    enabledInteractionables.Add(interactionable);
                eventInteractionable.pressFToInteract.SetActive(false);

            }

            if (enabledInteractionables.Count > 0)
            {
                Collider closestCollider = enabledInteractionables.OrderBy(
                    collider => Vector3.Distance(collider.transform.position, this.transform.position)).FirstOrDefault();
                activeInteractionable = closestCollider.GetComponent<EventInteractionable>();
                activeInteractionable.GetComponent<EventInteractionable>().pressFToInteract.SetActive(true);
            }
        }
        activeInteractionable?.RotateText(cam.gameObject);

        if (Input.GetKeyDown(KeyCode.F))
            activeInteractionable?.OnInteract();

        latestActiveInteractionable = activeInteractionable;
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        bool wave = Input.GetAxisRaw("Wave") > 0;
        float up = Input.GetAxisRaw("Jump");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        Vector3 moveDir = Vector3.zero;


        if (direction.magnitude >= 0.1f)
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
        HandleAnimation(wave, direction);

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

    private void HandleAnimation(bool wave, Vector3 direction)
    {
        animator.SetFloat("inputMagnitude", direction.magnitude);
        animator.SetBool("wave", wave);
        animator.SetBool("isOnGround", controller.isGrounded);
        animator.SetFloat("ySpeed", ySpeed);
    }
}
