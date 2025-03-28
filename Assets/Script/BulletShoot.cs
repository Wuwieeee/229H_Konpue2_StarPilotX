using UnityEngine;

public class BulletShoot : MonoBehaviour
{
    public GameObject bulletPrefab;  // Prefab ของกระสุนที่ต้องการยิง
    public Transform firePoint;      // จุดที่กระสุนจะออก (ตำแหน่งปากปืน)

    void Update()
    {
        // ตรวจสอบว่าผู้เล่นคลิกซ้ายเมาส์
        if (Input.GetMouseButtonDown(0))  // 0 หมายถึงการคลิกซ้าย
        {
            FireBullet();
        }
    }

    void FireBullet()
    {
        // สร้างกระสุนจากจุดยิง (firePoint) และทำให้กระสุนหมุนตามปากกระบอกปืน
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
