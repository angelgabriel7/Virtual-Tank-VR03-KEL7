using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    [Header("References")]
    public Transform turret;       // Bagian atas tank yang berputar horizontal
    public Transform barrel;       // Laras meriam yang bisa naik-turun
    public Transform cameraPivot;  // Transform kamera FPV atau pivot-nya

    [Header("Settings")]
    public float turretRotateSpeed = 5f;
    public float barrelRotateSpeed = 5f;
    public float minPitch = -5f;   // Sudut minimum barrel ke bawah
    public float maxPitch = 30f;   // Sudut maksimum barrel ke atas

    void Update()
    {
        AimTurret();
        AimBarrel();
    }

    void AimTurret()
    {
        // Hitung arah target dari kamera, abaikan Y (horizontal saja)
        Vector3 direction = cameraPivot.forward;
        direction.y = 0f;

        if (direction.sqrMagnitude < 0.001f) return;

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        turret.rotation = Quaternion.Slerp(turret.rotation, targetRotation, Time.deltaTime * turretRotateSpeed);
    }

    void AimBarrel()
    {
        Vector3 localDir = turret.InverseTransformDirection(cameraPivot.forward);
        float pitch = Mathf.Atan2(localDir.y, localDir.z) * Mathf.Rad2Deg;

        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        Vector3 currentRotation = barrel.localEulerAngles;
        currentRotation.x = NormalizeAngle(-pitch); // dibalik
        barrel.localEulerAngles = currentRotation;
    }

    float NormalizeAngle(float angle)
    {
        // Menghindari nilai > 180 agar rotasi tidak terbalik
        while (angle < 0f) angle += 360f;
        while (angle > 360f) angle -= 360f;
        return angle;
    }
}
