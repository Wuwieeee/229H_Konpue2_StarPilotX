using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // ความเร็วของกระสุน
    public float lifespan = 10f; // เวลาที่กระสุนจะอยู่ในเกม (10 วินาที)
    public int pointsPerEnemy = 10; // คะแนนที่จะได้รับเมื่อยิงศัตรู


    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime); // เคลื่อนที่ไปข้างหน้า
        Destroy(gameObject, lifespan);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) // ตรวจสอบว่าชนกับ Enemy หรือไม่
        {
            ScoreManager.Instance.AddScore(pointsPerEnemy);

            Destroy(other.gameObject); // ลบศัตรูออกจากเกม
            Destroy(gameObject); // ลบกระสุนออกจากเกม
        }
    }
}
