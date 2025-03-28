using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet")) // ตรวจสอบว่าชนกับกระสุน
        {
            Destroy(other.gameObject); // ทำลายกระสุน
            Destroy(gameObject); // ทำลายศัตรู
        }
    }
}
