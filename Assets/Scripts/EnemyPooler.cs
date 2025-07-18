using System.Collections.Generic;
using UnityEngine;

public class EnemyPooler : MonoBehaviour
{
    public static EnemyPooler Instance;

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int poolSize;

    private Queue<GameObject> pool = new();

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false);
            pool.Enqueue(enemy);
        }
    }

    public GameObject GetEnemy(Vector3 position)
    {
        if (pool.Count == 0) return null;

        GameObject enemy = pool.Dequeue();
        enemy.transform.position = position;
        enemy.transform.rotation = Quaternion.identity;
        enemy.SetActive(true);
        return enemy;
    }

    public void ReturnEnemy(GameObject enemy)
    {
        enemy.transform.position = Vector3.zero;
        enemy.SetActive(false);
        pool.Enqueue(enemy);

    }
}
