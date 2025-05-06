using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectIdentifier : MonoBehaviour
{
    public Camera playerCamera;
    public float maxDistance = 100f;
    public TextMeshProUGUI uiText; // UI tempat menampilkan nama objek
    public GameObject uiIndicatorObject;

    private IdentifiableObject lastTarget;

    void Update()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            IdentifiableObject idObj = hit.collider.GetComponent<IdentifiableObject>();

            if (idObj != null)
            {
                // Tampilkan nama objek
                uiText.text = idObj.displayName;
                uiText.enabled = true;
                uiIndicatorObject.SetActive(true); // Tampilkan indikator UI
                lastTarget = idObj;
                return;
            }
        }

        // Tidak ada objek valid yang sedang disorot
        uiText.enabled = false;
        uiIndicatorObject.SetActive(false); // Sembunyikan indikator UI
        lastTarget = null;
    }
}
