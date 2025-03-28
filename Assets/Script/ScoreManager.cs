using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; // ตัวแปรอ้างอิงถึง UI Text
    private int score = 0;

    void Start()
    {
        UpdateScoreText(); // เริ่มต้นการแสดงคะแนน
    }

    public void AddScore(int points)
    {
        score += points; // เพิ่มคะแนน
        UpdateScoreText(); // อัพเดต UI
    }

    private void UpdateScoreText()
    {
        scoreText.text = "คะแนน: " + score; // แสดงคะแนนบน UI
    }
}
