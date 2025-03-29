using TMPro;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameManager gameManager;
    public float speed = 10f; // ความเร็วของกระสุน
    public float lifespan = 10f; // เวลาที่กระสุนจะอยู่ในเกม (10 วินาที)
  
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime); // เคลื่อนที่ไปข้างหน้า
        Destroy(gameObject, lifespan);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject); // ลบศัตรูออกจากเกม
            Destroy(gameObject); // ลบกระสุนออกจากเกม
        }
    }
}
