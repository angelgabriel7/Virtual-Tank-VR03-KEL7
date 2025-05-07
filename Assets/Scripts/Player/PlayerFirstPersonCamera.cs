using UnityEngine;

public class PlayerFirstPersonCamera : MonoBehaviour
{
    public Transform cameraPivot; // Pivot kamera di dalam kokpit
    public float mouseSensitivity = 3f;
    public float minPitch = -30f;
    public float maxPitch = 45f;

    private float yaw = 0f;
    private float pitch = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        yaw += mouseX;
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        cameraPivot.localRotation = Quaternion.Euler(pitch, yaw, 0f);
    }
}
