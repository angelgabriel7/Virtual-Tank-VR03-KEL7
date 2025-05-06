using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifetime = 5f;
    public GameObject hitEffectPrefab;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Efek hit
        if (hitEffectPrefab != null)
        {
            GameObject vfx = Instantiate(hitEffectPrefab, collision.contacts[0].point, Quaternion.LookRotation(collision.contacts[0].normal));
            Destroy(vfx, 2f);
        }

        if (collision.gameObject.CompareTag("Target"))
        {
            Destroy(collision.gameObject);
        }

        GameManager.Instance.PlayExplosionSfx();

        Destroy(gameObject, 0.1f);
    }
}
