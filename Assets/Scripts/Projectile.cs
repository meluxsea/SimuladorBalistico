using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform launchPoint;
    public float launchForce = 10f; 
    private float launchAngle = 45f; 
    public float horizontalOffset = 0f; 
    public float verticalOffset = 0f;
    private GameObject currentProjectile;

    
    public void SetLaunchParameters(float angle, float force, float horizontal, float vertical)
    {
        launchAngle = angle;
        launchForce = force;

        
        horizontalOffset = horizontal;
        verticalOffset = vertical;
        transform.position = new Vector3(horizontalOffset, verticalOffset, transform.position.z);
    }

    
    public void Shoot()
    {
        
        if (currentProjectile != null)
        {
            Destroy(currentProjectile);
        }

      
        currentProjectile = Instantiate(projectilePrefab, launchPoint.position, launchPoint.rotation);
        Rigidbody rb = currentProjectile.GetComponent<Rigidbody>();

        
        if (rb != null)
        {
            float angleInRadians = launchAngle * Mathf.Deg2Rad;
            Vector3 direction = new Vector3(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians), 0).normalized;
            rb.AddForce(direction * launchForce, ForceMode.Impulse);
        }
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Objects destructible = collision.gameObject.GetComponent<Objects>();
            if (destructible != null)
            {
                destructible.DestroyObject();
            }

            Destroy(gameObject);

        }
    }
}
