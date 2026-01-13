using UnityEngine;

public class OverShoulderCamera : MonoBehaviour
{
    public Transform target;                       // Player or target to follow
    public Vector3 shoulderOffset = new Vector3(0.5f, 1.6f, -2.5f);

    public float mouseSensitivity = 3f;
    public float followSpeed = 10f;                // Smooth position speed
    public float minY = -30f;
    public float maxY = 60f;

    private float yaw;
    private float pitch;

    private Vector3 currentVelocity;               // Used by SmoothDamp

    void LateUpdate()
    {
        HandleRotation();
        FollowTarget();
    }

    void HandleRotation()
    {
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, minY, maxY);

        transform.rotation = Quaternion.Euler(pitch, yaw, 0f);
    }

    void FollowTarget()
    {
        Vector3 desiredPosition = target.position + transform.rotation * shoulderOffset;

        // Smooth the camera movement using SmoothDamp instead of Lerp
        transform.position = Vector3.SmoothDamp(
            transform.position,
            desiredPosition,
            ref currentVelocity,
            1f / followSpeed
        );
    }
}
