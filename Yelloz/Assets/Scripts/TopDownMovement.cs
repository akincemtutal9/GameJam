using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    private Vector3 playerVelocity;
    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float gravity;
    [SerializeField] private bool isGrounded;
    [SerializeField] private float jumpHeight; 
    private CharacterController controller;
    private Animator animator;
    
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
    
    private void Update()
    {
        isGrounded = controller.isGrounded;
        
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);
        moveDirection.Normalize();
       
        controller.Move(moveDirection * (speed * Time.deltaTime));
        
        if(moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotateSpeed * Time.deltaTime);
            
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }

        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
