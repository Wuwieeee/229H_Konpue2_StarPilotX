using UnityEngine;
using UnityEngine.UI; // Use TMPro is using TexMeshPro

public class CreditScript : MonoBehaviour
{
    public float scrollSpeed = 40f; // Adjest the speed of the scroll
    private RectTransform rectTransform;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        rectTransform.anchoredPosition += new Vector2(0 , scrollSpeed * Time.deltaTime);
    }
}
