using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;           // Kecepatan maju/mundur
    public float turnSpeed = 60f;          // Kecepatan belok (derajat per detik)

    private Rigidbody rb;
    private float moveInput;
    private float turnInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Input dari pemain (WASD atau Arrow Keys)
        moveInput = Input.GetAxis("Vertical");   // W/S atau Up/Down
        turnInput = Input.GetAxis("Horizontal"); // A/D atau Left/Right
    }

    void FixedUpdate()
    {
        // Gerakan maju/mundur
        Vector3 move = transform.forward * moveInput * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + move);

        // Putar tank (belok kiri/kanan)
        float turn = turnInput * turnSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}
