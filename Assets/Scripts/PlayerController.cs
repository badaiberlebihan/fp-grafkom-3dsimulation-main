using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 3.0f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float groundCheckDistance = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    private CameraController cameraController;
    private Animator animator;
    private CharacterController characterController;
    private Vector3 velocity;
    private bool isGrounded;

    void Awake()
    {
        cameraController = Camera.main.GetComponent<CameraController>();
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundLayer);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveInput = new Vector3(horizontal, 0, vertical).normalized;
        Vector3 moveDir = cameraController.PlanarRotation() * moveInput;

        if (moveInput.magnitude > 0)
        {
            characterController.Move(moveDir * speed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(moveDir);
        }

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        animator.SetFloat("moveAmount", moveInput.magnitude);
    }

    // private void OnDrawGizmos()
    // {
    //     // Visualisasi Ground Check
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawSphere(transform.position, groundCheckDistance);
    // }
}
