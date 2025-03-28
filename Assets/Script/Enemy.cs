using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    
    public int scoreValue = 10; // คะแนนที่ได้เมื่อทำลายศัตรู

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet")) // เช็คว่าโดนกระสุนหรือไม่
        {
            
            Destroy(other.gameObject); // ทำลายกระสุน
            Destroy(gameObject); // ทำลายศัตรู
        }
    }
}
