using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;  // ตัวแปร static สำหรับเรียกใช้งาน
    public Text scoreText;  // UI Text สำหรับแสดงคะแนน
    private static int score = 0;  // ตัวแปรสำหรับเก็บคะแนน

    // สร้าง Singleton ให้กับ ScoreManager
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // ตั้งค่า UI Text เริ่มต้น
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    public static void IncreaseScore()
    {
        score++;
    }

    public static int GetScore()
    {
        return score;
    }

    public void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}

