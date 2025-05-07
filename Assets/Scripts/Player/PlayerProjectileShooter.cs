using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileShooter : MonoBehaviour
{
    [Header("References")]
    public Transform firePoint;               // Tempat keluarnya peluru (ujung barrel)
    public GameObject projectilePrefab;       // Prefab peluru
    public float projectileForce = 1000f;

    [Header("Input")]
    public KeyCode shootKey = KeyCode.Mouse0;
    public float shootCooldown = 1f;

    private float lastShootTime;

    void Update()
    {
        if (Input.GetKeyDown(shootKey) && Time.time >= lastShootTime + shootCooldown)
        {
            Shoot();
            lastShootTime = Time.time;
        }
    }

    void Shoot()
    {
        // Spawn dan tembak peluru
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(firePoint.forward * projectileForce);
        }

        GameManager.Instance.PlayShotSfx();
    }
}
