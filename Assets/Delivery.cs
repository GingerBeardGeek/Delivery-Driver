using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage;
    [SerializeField] float destroySpeed = 0.1f;
    [SerializeField] Color32 hasPackageColor = new Color32 (173,97,58,255);
    [SerializeField] Color32 noPackageColor = new Color32 (255,255,255,255);
    SpriteRenderer spriteRenderer;

    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package Collected.");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject,destroySpeed);
        }
        else if (other.tag == "DeliveryPoint" && hasPackage)
        {
            Debug.Log("Package Delivered.");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
