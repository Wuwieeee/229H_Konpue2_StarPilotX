using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; 
    private int score = 0;
    public static ScoreManager Instance;
    
    void Awake()
    {
        // ตรวจสอบและกำหนด Instance ของ ScoreManager
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // หากมี Instance อยู่แล้วให้ลบตัวเอง
        }
    }
    void Start()
    {
        UpdateScoreText(); 
    }

    public void AddScore(int points)
    {
        score += points; 
        UpdateScoreText(); 
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score; // อัปเดตข้อความ UI
    }

}
