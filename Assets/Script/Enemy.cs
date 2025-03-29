using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private static int score = 0; 

    private void Start()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.UpdateScoreText();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            GameManager.IncreaseScore();
            Destroy(other.gameObject);
            Destroy(gameObject); 
            if (GameManager.Instance != null)
            {
                GameManager.Instance.UpdateScoreText();
            }
        }
    }
}
