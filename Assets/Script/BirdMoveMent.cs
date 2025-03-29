using Unity.VisualScripting;
using UnityEngine;

public class BirdMoveMent : MonoBehaviour
{
    
    public float speed = 3f;
    private Vector3 moveDirection;

    void Start()
    {
        InvokeRepeating(nameof(ChangeDirection), 0, 3f); 
    }

    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }

    void ChangeDirection()
    {
        float moveX = Random.Range(-1f, 1f);
        float moveZ = Random.Range(-1f, 1f);
        moveDirection = new Vector3(moveX, 0, moveZ).normalized; 
    }  
}
