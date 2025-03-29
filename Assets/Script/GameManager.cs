using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;  
    public Text scoreText;  
    private static int score = 0; 
    public Text messageText;

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
        StartCoroutine(ShowMessageForSeconds(" shoot 20 birds", 3f));
  
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    public static void IncreaseScore()
    {
        score++;
        if (score >= 20)
        {
            SceneManager.LoadScene("Credit");  
        }
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

    IEnumerator ShowMessageForSeconds(string message, float duration)
    {
        messageText.text = message;
        yield return new WaitForSeconds(duration);
        messageText.text = "";
    }
}

