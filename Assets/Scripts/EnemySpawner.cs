using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyPooler enemyPooler;
    [SerializeField] private float spawnInterval;
    [SerializeField] private Transform[] spawnPoints;

    private float spawnTime = 0f;


    void Update()
    {

        spawnTime += Time.deltaTime;
        if (spawnTime >= spawnInterval)
        {
            SpawnEnemy();
            spawnTime = 0f;
        }
    }

    private void SpawnEnemy()
    {
        int index = Random.Range(0, spawnPoints.Length);
        GameObject enemy = enemyPooler.GetEnemy(spawnPoints[index].position);


        if (enemy != null)
        {
            enemy.transform.position = spawnPoints[index].position;
            enemy.GetComponent<Enemy>().ResetState();
        }
    }
}
