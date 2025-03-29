using UnityEngine;

public class BulletShoot : MonoBehaviour
{
    public GameObject bulletPrefab;  
    public Transform firePoint;

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            FireBullet();
        }
    }
    void FireBullet()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
