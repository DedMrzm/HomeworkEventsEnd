using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Task27_28
{
    public class EnemyService : MonoBehaviour
    {
        private List<Enemy> _enemies = new List<Enemy>();

        private Dictionary<Enemy, Func<bool>> _enemiesAndDestroyConditionDictionary = new Dictionary<Enemy, Func<bool>>();

        public int EnemiesCounter => _enemies.Count;
    
        private void Update()
        {
            Debug.Log(_enemies.Count);

            foreach(Enemy enemy in _enemiesAndDestroyConditionDictionary.Keys)
            {
                if (_enemiesAndDestroyConditionDictionary[enemy]() == true)
                {
                    _enemies.Remove(enemy);
                    _enemiesAndDestroyConditionDictionary.Remove(enemy);
                    enemy.Kill();
                    return;
                }
            }
        }

        public void AddEnemy(Enemy enemy, Func<bool> deathCondition)
        {
            _enemies.Add(enemy);
            _enemiesAndDestroyConditionDictionary.Add(enemy, deathCondition);
        }
    }
}
