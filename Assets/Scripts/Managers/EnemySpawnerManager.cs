using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawnerManager : Singleton<EnemySpawnerManager>
{
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private GameObject[] enemyPool = null;
    [SerializeField] private List<GameObject> enemyCurrentList = null;
    [SerializeField] private bool canSpawn = false;
    [SerializeField] private int maxEnemyCap = 10;

    public List<GameObject> EnemyCurrentList => enemyCurrentList;

    void Start()
    {
        canSpawn = true;
        StartCoroutine(Spawner());
    }

    void Update()
    {
        SortEnemyList();
    }

    private IEnumerator Spawner()
    {
        while (canSpawn && enemyCurrentList.Count < maxEnemyCap)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnRate);
        }
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

    private void RemoveEnemyToList(GameObject _enemy)
    {
        enemyCurrentList.Remove(_enemy);
    }

    private void SortEnemyList()
    {
        enemyCurrentList.OrderBy(x => Vector2.Distance(this.transform.position, StatsManager.Instance.GetComponent<Transform>().position)).ToList();
    }
}