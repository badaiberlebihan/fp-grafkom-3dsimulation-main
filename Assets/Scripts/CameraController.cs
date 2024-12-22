using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform followTarget;
    [SerializeField] private float rotationSpeed = 1.0f;
    [SerializeField] private float distance = 5.0f;
    [SerializeField] private float minVerticalAngle = -45.0f;
    [SerializeField] private float maxVerticalAngle = 45.0f;
    [SerializeField] private Vector2 framingOffset;

    private float rotationX;
    private float rotationY;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        rotationX = 20.0f;
        rotationY = 0.0f;

        UpdateCameraPosition();
    }

    void Update()
    {
        rotationX += Input.GetAxis("Mouse Y") * rotationSpeed;
        rotationX = Mathf.Clamp(rotationX, minVerticalAngle, maxVerticalAngle);
        rotationY += Input.GetAxis("Mouse X") * rotationSpeed;

        UpdateCameraPosition();
    }

    void UpdateCameraPosition()
    {
        Quaternion targetRotation = Quaternion.Euler(rotationX, rotationY, 0);

        Vector3 focusPosition = followTarget.position + new Vector3(framingOffset.x, framingOffset.y);

        transform.position = focusPosition - targetRotation * new Vector3(0, 0, distance);
        transform.rotation = targetRotation;
    }

    public Quaternion PlanarRotation()
    {
        return Quaternion.Euler(0, rotationY, 0);
    }
}
