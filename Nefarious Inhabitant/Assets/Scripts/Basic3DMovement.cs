using UnityEngine;

public class Basic3DMovement : MonoBehaviour
{
    public float speed = 5f;
    public Transform cameraTransform;

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Get camera forward/right, flattened on XZ plane
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = (forward * z + right * x) * speed * Time.deltaTime;
        transform.Translate(moveDirection, Space.World);
    }
}
