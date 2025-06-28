using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private EnemyService _enemyService;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameObject enemy = Instantiate(_enemyPrefab);

            enemy.name = "EnemyLifeTimeCondition 2seconds";
            _enemyService.AddEnemy(enemy.GetComponent<Enemy>(), () => enemy.GetComponent<Enemy>().LifeTime > 5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GameObject enemy = Instantiate(_enemyPrefab);

            enemy.name = "EnemyIsDeadCondition";
            _enemyService.AddEnemy(enemy.GetComponent<Enemy>(), () => enemy.GetComponent<Enemy>().IsDead);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GameObject enemy = Instantiate(_enemyPrefab);

            enemy.name = "EnemyCounterCondition Less 5";
            _enemyService.AddEnemy(enemy.GetComponent<Enemy>(), () => _enemyService.EnemiesCounter > 5);
        }
    }
}
