using UnityEngine;

public class Enemy : MonoBehaviour
{
    public UiText uiText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet")) // ตรวจสอบว่าชนกับกระสุน
        {
            Destroy(other.gameObject); // ทำลายกระสุน
            Destroy(gameObject); // ทำลายศัตรู
            
        }
    }
    void Die()
    {
        // Logic for enemy death (e.g., destroying the enemy)
        Destroy(gameObject);

        // Call the method to update the score
        uiText.EnemyDied();
    }
}
