using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnemySpawnerManager : Singleton<EnemySpawnerManager>
{
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private GameObject[] enemyPool = null;
    [SerializeField] private List<GameObject> enemyCurrentList = null;
    [SerializeField] private bool canSpawn = true;

    void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (canSpawn) yield return wait;

        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        GameObject _enemyToSpawn = enemyPool[0];
        Instantiate(_enemyToSpawn, transform.position, Quaternion.identity);
        AddEnemyToList(_enemyToSpawn);
    }

    private void AddEnemyToList(GameObject _enemy)
    {
        enemyCurrentList.Add(_enemy);
    }

    //private void RemoveEnemyToList(GameObject _enemy)
    //{
    //    enemyCurrentList.Remove(_enemy);
    //}
}