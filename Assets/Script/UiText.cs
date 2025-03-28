using UnityEngine;
using UnityEngine.UI;

public class UiText : MonoBehaviour
{
    public Text scoreText;  // Text UI สำหรับแสดงคะแนน

    private int score = 0;

    private void Start()
    {
        UpdateScoreText();  // เริ่มต้นแสดงคะแนนเมื่อเริ่มเกม
    }

    // วิธีการอัปเดตคะแนน
    void UpdateScoreText()
    {
        scoreText.text = score.ToString() + " Score";  // อัปเดตข้อความใน UI ด้วยคะแนนปัจจุบัน
    }

    // เรียกใช้เมธอดนี้เมื่อศัตรูตาย
    public void EnemyDied()
    {
        score += 10;  // เพิ่มคะแนน 10 เมื่อศัตรูตาย
        UpdateScoreText();  // อัปเดต UI ให้แสดงคะแนนใหม่
    }
}
