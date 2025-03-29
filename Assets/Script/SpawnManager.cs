using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // Array ของ Prefab ที่ใช้สุ่ม
    public Transform spawnPoint; // จุดที่ต้องการ Spawn
    public int spawnAmount = 5; // จำนวนวัตถุที่ Spawn ต่อรอบ
    public float spawnInterval = 2f; // เวลาหน่วงระหว่างรอบการ Spawn

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            for (int i = 0; i < spawnAmount; i++)
            {
                SpawnRandomObject();
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnRandomObject()
    {
        if (objectsToSpawn.Length == 0) return; // ป้องกัน Error ถ้าไม่มี Prefab ใน Array

        int randomIndex = Random.Range(0, objectsToSpawn.Length); // สุ่ม Prefab
        GameObject randomPrefab = objectsToSpawn[randomIndex];

        Instantiate(randomPrefab, spawnPoint.position, Quaternion.identity);
    }
}
