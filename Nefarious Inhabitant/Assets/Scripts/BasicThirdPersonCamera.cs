using UnityEngine;

public class BasicThirdPersonCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 2f, -5f);
    public float mouseSensitivity = 3f;

    private float yaw;
    private float pitch;

    void LateUpdate()
    {
        if (target == null) return;

        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, -30f, 60f);

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);
        Vector3 rotatedOffset = rotation * offset;

        transform.position = target.position + rotatedOffset;
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}
