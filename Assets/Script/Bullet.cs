using TMPro;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameManager gameManager;
    public float speed = 10f;
    public float lifespan = 10f; 
  
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime); 
        Destroy(gameObject, lifespan);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject); 
            Destroy(gameObject);
        }
    }
}
