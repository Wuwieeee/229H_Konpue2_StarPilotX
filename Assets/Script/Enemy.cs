using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  // สำหรับ UI

public class Enemy : MonoBehaviour
{
    private static int score = 0;  // ตัวแปรสำหรับเก็บคะแนน

    private void Start()
    {
        // ตรวจสอบว่า ScoreManager อยู่ใน Scene หรือไม่
        if (GameManager.Instance != null)
        {
            GameManager.Instance.UpdateScoreText();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet")) // เช็คว่าโดนกระสุนหรือไม่
        {
            GameManager.IncreaseScore();
            Destroy(other.gameObject); // ทำลายกระสุน
            Destroy(gameObject); // ทำลายศัตรู
            if (GameManager.Instance != null)
            {
                GameManager.Instance.UpdateScoreText();
            }
        }
    }
}
